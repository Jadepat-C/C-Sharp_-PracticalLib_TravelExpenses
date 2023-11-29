using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using PracticalLib.Data;
using PracticalLib.Models;
using PracticalLib.MyDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Student Name: Jadepat Chernsonthi
 * Student Number: 041074866
 * Student Email: cher0151@algonquinlive.com
 * Course & Section #: 23F_CST8333_370
 */
namespace PracticalLib.Logic
{
    /// <summary>
    /// Represents a business logic for DAO.
    /// </summary>
    public class TravelExpensesLogic : ITravelExpensesLogic
    {
        private ITravelExpensesDao dao;
        private TravelExpensesDbContext dbContext = new TravelExpensesDbContext();

        /// <summary>
        /// Constructor for initialize DAO
        /// </summary>
        public TravelExpensesLogic()
        {
            dao = new TravelExpensesDao(dbContext);
        }

        /// <inheritdoc/>
        public void Delete(string id)
        {
            try
            {
                dao.Delete(id);
            }
            catch
            {
                throw;
            }

        }

        /// <inheritdoc/>
        public List<TravelExpensesEntity> Get(int numOfInstances, int numOfSkip)
        {
            try
            {
                return dao.Get(numOfInstances, numOfSkip);
            }
            catch
            {
                throw;
            }

        }

        /// <inheritdoc/>
        public TravelExpensesEntity GetByID(string id)
        {
            try
            {
                return dao.GetByID(id);
            }
            catch
            {
                throw;
            }

        }

        /// <inheritdoc/>
        public List<TravelExpensesEntity> GetByRefNumber(string refNumber)
        {
            try
            {
                return dao.GetByRefNumber(refNumber);
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public void Insert(TravelExpensesEntity travelExpense)
        {
            try
            {
                Validate(travelExpense);
                dao.Insert(travelExpense);
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public void Update(TravelExpensesEntity travelExpense)
        {
            try
            {
                Validate(travelExpense);
                dao.Update(travelExpense);
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public int GetCount()
        {
            try
            {
                return dao.GetCount();
            }
            catch
            {
                throw;
            }

        }

        /// <inheritdoc/>
        public List<TravelExpensesEntity> Search(string query)
        {
            try
            {
                return dao.Search(query);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Private method for validating object before doing the operation
        /// </summary>
        /// <param name="travelExpense">The travel expense entity to validate</param>
        private void Validate(TravelExpensesEntity travelExpense)
        {
            try
            {
                #region validation
                ValidateString(travelExpense?.RefNumber, "Ref Number", false);
                ValidateString(travelExpense?.TitleEn, "Title", false);
                ValidateString(travelExpense?.PurposeEn, "Purpose", false);
                ValidateDate(travelExpense?.StartDate, travelExpense?.EndDate, false);
                if (travelExpense.Airfare == null)
                {
                    travelExpense.Airfare = 0;
                }
                ValidateFloat(travelExpense?.Airfare, "Airfare", false);
                if (travelExpense.OtherTransport == null)
                {
                    travelExpense.OtherTransport = 0;
                }
                ValidateFloat(travelExpense?.OtherTransport, "Other Transport", false);
                if (travelExpense.Lodging == null)
                {
                    travelExpense.Lodging = 0;
                }
                ValidateFloat(travelExpense?.Lodging, "Lodging", false);
                if (travelExpense.Meals == null)
                {
                    travelExpense.Meals = 0;
                }
                ValidateFloat(travelExpense?.Meals, "Meals", false);
                if (travelExpense.OtherExpenses == null)
                {
                    travelExpense.OtherExpenses = 0;
                }
                ValidateFloat(travelExpense?.OtherExpenses, "Other Expenses", false);
                CalculateTotal(travelExpense!);
                ValidateFloat(travelExpense?.Total, "Total", false);
                #endregion
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Private validate method to help validate string
        /// </summary>
        /// <param name="str">The string to validate</param>
        /// <param name="fieldName">The field name of the string</param>
        /// <param name="isNullAllowed">Can the field be null?</param>
        /// <exception cref="InvalidDataException">When the string does not pass the validation</exception>
        private void ValidateString(string? str, string fieldName, bool isNullAllowed)
        {
            if (!isNullAllowed)
            {
                if (string.IsNullOrWhiteSpace(str) || str is null)
                {
                    throw new InvalidDataException($"{fieldName} cannot be empty or whitespace");
                }
            }
            else { return; }
        }

        /// <summary>
        /// Private validate method to help validate floating point number
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <param name="fieldName">The field of the value</param>
        /// <param name="isNullAllowed">Can the field be null?</param>
        /// <exception cref="InvalidDataException">When the floating point number does not pass the validation</exception>
        private void ValidateFloat(decimal? value, string fieldName, bool isNullAllowed)
        {
            if (!isNullAllowed)
            {
                if (value < 0)
                {
                    throw new InvalidDataException($"{fieldName} cannot be negative");
                }
            }
            else { return; }
        }

        /// <summary>
        /// Private validate method to help validate date
        /// </summary>
        /// <param name="startDate">Start date as a string</param>
        /// <param name="endDate">End date as a string</param>
        /// <param name="isNullAllowed">Can the field be null?</param>
        /// <exception cref="InvalidDataException">When the date does not pass the validation</exception>
        /// <exception cref="ArgumentException">When entering empty string</exception>
        /// <exception cref="FormatException">When the date is not in the valid format</exception>
        private void ValidateDate(DateTime? startDate, DateTime? endDate, bool isNullAllowed)
        {
            if (!isNullAllowed)
            {
                if (startDate.HasValue && endDate.HasValue)
                {
                    if (startDate.Value > endDate.Value)
                    {
                        throw new InvalidDataException("Start date cannot be later than end date");
                    }
                }
                else if (!startDate.HasValue && !endDate.HasValue)
                {
                    throw new ArgumentException("Dates cannot be empty");
                }
                else if (!startDate.HasValue)
                {
                    throw new ArgumentException("Start date cannot be empty");
                }
                else if (!endDate.HasValue)
                {
                    throw new ArgumentException("End date cannot be empty");
                }
            }
        }

        private void CalculateTotal(TravelExpensesEntity entity)
        {
            entity.Total = entity.Airfare + entity.OtherTransport + entity.Lodging + entity.Meals + entity.OtherExpenses;
        }
    }
}
