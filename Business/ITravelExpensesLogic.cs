using CsvHelper;
using CsvHelper.Configuration.Attributes;
using PracticalLib.Models;
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
    /// Represent interface for Bussiness Logic of travel expenses object
    /// </summary>
    internal interface ITravelExpensesLogic
    {
        /// <summary>
        /// Retrieves all travel expenses.
        /// </summary>
        /// <returns>A list of all travel expenses.</returns>
        public List<TravelExpensesEntity> Get(int numOfInstances, int numOfSkip);

        /// <summary>
        /// Retrieves travel expenses by reference number.
        /// </summary>
        /// <param name="refNumber">The reference number to search for.</param>
        /// <returns>A list of travel expenses matching the reference number.</returns>
        public List<TravelExpensesEntity> GetByRefNumber(string refNumber);

        /// <summary>
        /// Retrieves a travel expense by its ID.
        /// </summary>
        /// <param name="id">The ID of the travel expense to retrieve.</param>
        /// <returns>The travel expense with the specified ID.</returns>
        public TravelExpensesEntity GetByID(string id);

        /// <summary>
        /// Inserts a new travel expense record.
        /// </summary>
        /// <param name="travelExpense">The travel expense object to insert.</param>
        public void Insert(TravelExpensesEntity travelExpense);


        /// <summary>
        /// Updates an existing travel expense record.
        /// </summary>
        /// <param name="travelExpense">The travel expense object to update.</param>
        public void Update(TravelExpensesEntity travelExpense);

        /// <summary>
        /// Deletes a travel expense record by its ID.
        /// </summary>
        /// <param name="id">The ID of the travel expense to delete.</param>
        public void Delete(string id);

        /// <summary>
        /// Retrieves a number of instance.
        /// </summary>
        /// <returns>number of instances in the table.</returns>
        public int GetCount();

        /// <summary>
        /// Retrieves up to 5,000 travel expenses instances by any string value inputed.
        /// </summary>
        /// <param name="query">The string to search for.</param>
        /// <returns>A list of travel expenses matching the string.</returns>
        public List<TravelExpensesEntity> Search(string query);
    }
}
