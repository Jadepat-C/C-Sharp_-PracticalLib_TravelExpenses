using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PracticalLib.Models;
using PracticalLib.MyDbContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
/*
 * Student Name: Jadepat Chernsonthi
 * Student Number: 041074866
 * Student Email: cher0151@algonquinlive.com
 * Course & Section #: 23F_CST8333_370
 */
namespace PracticalLib.Data
{
    /// <summary>
    /// Represents a Data Access Object (DAO) for managing travel expenses.
    /// </summary>
    public class TravelExpensesDao : ITravelExpensesDao
    {

        private TravelExpensesDbContext db;

        /// <summary>
        /// Constuctor to initialize Data Access variable and import dataset
        /// </summary>
        public TravelExpensesDao(TravelExpensesDbContext dbContext)
        {
            this.db = dbContext;
        }

        /// <inheritdoc />
        /// <exception cref="NullReferenceException">When cannot find dataset</exception>
        /// <exception cref="ArgumentNullException">when insert null entity</exception>
        public void Insert(TravelExpensesEntity travelExpense)
        {

            travelExpense.Id = Guid.NewGuid().ToString();
            try
            {
                db.TravelExpenses.Add(travelExpense);
                db.SaveChanges();
            }
            catch
            {
                throw new DbUpdateException("Cannot insert new data");
            }
        }

        /// <inheritdoc/>
        /// <exception cref="DbUpdateException">When cannot update instance</exception>
        public void Update(TravelExpensesEntity travelExpense)
        {
            var updateItem = GetByID(travelExpense.Id);
            try
            {
                #region set variable
                updateItem.RefNumber = travelExpense.RefNumber;
                updateItem.DisclosureGroup = travelExpense.DisclosureGroup;
                updateItem.TitleEn = travelExpense.TitleEn;
                updateItem.TitleFr = travelExpense.TitleFr;
                updateItem.Name = travelExpense.Name;
                updateItem.PurposeEn = travelExpense.PurposeEn;
                updateItem.PurposeFr = travelExpense.PurposeFr;
                updateItem.StartDate = travelExpense.StartDate;
                updateItem.EndDate = travelExpense.EndDate;
                updateItem.DestinationEn = travelExpense.DestinationEn;
                updateItem.DestinationFr = travelExpense.DestinationFr;
                updateItem.Airfare = travelExpense.Airfare;
                updateItem.OtherTransport = travelExpense.OtherTransport;
                updateItem.Lodging = travelExpense.Lodging;
                updateItem.Meals = travelExpense.Meals;
                updateItem.OtherExpenses = travelExpense.OtherExpenses;
                updateItem.Total = travelExpense.Total;
                updateItem.CommentsEn = travelExpense.CommentsEn;
                updateItem.CommentsFr = travelExpense.CommentsFr;
                updateItem.OwnerOrg = travelExpense.OwnerOrg;
                updateItem.OwnerOrgTitle = travelExpense.OwnerOrgTitle;
                #endregion
                db.SaveChanges();
            }
            catch
            {
                throw new DbUpdateException($"Cannot update instance id:{travelExpense.Id}");
            }
        }

        /// <inheritdoc/>
        /// <exception cref="DbUpdateException">When cannot delete instance</exception>
        public void Delete(string id)
        {
            var deleteItem = GetByID(id);
            try
            {
                db.TravelExpenses.Remove(deleteItem);
                db.SaveChanges();
            }
            catch
            {
                throw new DbUpdateException($"Cannot delete instance id:{id}");
            }

        }

        /// <inheritdoc/>
        public List<TravelExpensesEntity> Get(int numOfInstances, int numOfSkip)
        {
            int recordsToSkip = numOfSkip * numOfInstances;

            return db.TravelExpenses
                .OrderByDescending(f => f.EndDate)
                .Skip(recordsToSkip)
                .Take(numOfInstances)
                .ToList();            
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When cannot find data with reference number</exception>
        public List<TravelExpensesEntity> GetByRefNumber(string refNumber)
        {
            if (refNumber.IsNullOrEmpty())
            {
                throw new ArgumentNullException("Ref number cannot be null");
            }
            else
            {
                var returnList = db.TravelExpenses
                .Where(f => f.RefNumber.Equals(refNumber))
                .OrderByDescending(f => f.StartDate)
                .ThenByDescending(f => f.EndDate)
                .ToList();
                if (returnList == null)
                {
                    throw new NullReferenceException("Cannot find this ref number");
                }
                else
                {
                    return returnList;
                }
            }
        }

        /// <inheritdoc/>
        /// <exception cref="NullReferenceException">When cannot find data with id</exception>
        public TravelExpensesEntity GetByID(string id)
        {
            var returnItem = db.TravelExpenses.Where(f => f.Id.Equals(id)).FirstOrDefault();
            if (returnItem == null)
            {
                throw new NullReferenceException($"Cannot find instance with id:{id}");
            }
            else
            {
                return returnItem;
            }
        }

        /// <inheritdoc/>
        public int GetCount()
        {
            return db.TravelExpenses.Count();
        }

        /// <inheritdoc/>
        /// <exception cref="NullReferenceException">When cannot find data contain query</exception>
        public List<TravelExpensesEntity> Search(string query)
        {
            var dateQueryParameter = new SqlParameter("@dateQuery", SqlDbType.DateTime)
            {
                Value = DateTime.TryParse(query, out var date) ? date : (object)DBNull.Value
            };

            #region sql string
            string sqlQuery = $@"
                SELECT * FROM [practical-project].[travelq]
                WHERE 
                ref_number LIKE '%{query}%' OR
                title_en LIKE '%{query}%' OR
                purpose_en LIKE '%{query}%' OR
                start_date = @dateQuery OR
                end_date = @dateQuery OR
                airfare LIKE '{query}' OR
                other_transport LIKE '{query}' OR
                lodging LIKE '{query}' OR
                meals LIKE '{query}' OR
                other_expenses LIKE '{query}' OR
                total LIKE '{query}'
            ";
            #endregion

            var resultList = db.TravelExpenses
                .FromSqlRaw(sqlQuery, dateQueryParameter)
                .OrderByDescending(f => f.StartDate)
                .ThenByDescending(f => f.EndDate)
                //Return only 5000 instances from database to reduce load
                .Take(5000)
                .ToList();

            if (resultList == null)
            {
                throw new NullReferenceException($"There is no value contains {query}");
            } 
            else
            {
                
                return resultList;
            }
        }
    }
}
