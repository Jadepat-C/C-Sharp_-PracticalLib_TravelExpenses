using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

/*
 * Student Name: Jadepat Chernsonthi
 * Student Number: 041074866
 * Student Email: cher0151@algonquinlive.com
 * Course & Section #: 23F_CST8333_370
 */
namespace PracticalLib.Models
{
    /// <summary>
    /// Represents a Entity Object (DTO) for travel expenses.
    /// </summary>
    [Table("travelq", Schema = "practical-project")]
    public class TravelExpensesEntity
    {

        // Used column
        /// <summary>
        /// Gets or sets the ID of the travel expense.
        /// </summary>
        [Key]
        [Column("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the reference number of the travel expense.
        /// </summary>
        [Column("ref_number")]
        public string RefNumber { get; set; } = "";

        /// <summary>
        /// Gets or sets the title (English) of the travel expense.
        /// </summary>
        [Column("title_en")]
        public string? TitleEn { get; set; } = "";

        /// <summary>
        /// Gets or sets the purpose (English) of the travel expense.
        /// </summary>
        [Column("purpose_en")]
        public string? PurposeEn { get; set; } = "";

        /// <summary>
        /// Gets or sets the start date of the travel expense.
        /// </summary>
        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the travel expense.
        /// </summary>
        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the airfare cost of the travel expense.
        /// </summary>
        [Column("airfare")]
        public decimal? Airfare { get; set; } = 0;

        /// <summary>
        /// Gets or sets the other transport cost of the travel expense.
        /// </summary>
        [Column("other_transport")]
        public decimal? OtherTransport { get; set; } = 0;

        /// <summary>
        /// Gets or sets the lodging of the travel expense.
        /// </summary>
        [Column("lodging")]
        public decimal? Lodging { get; set; } = 0;

        /// <summary>
        /// Gets or sets the meals cost of the travel expense.
        /// </summary>
        [Column("meals")]
        public decimal? Meals { get; set; } = 0;

        /// <summary>
        /// Gets or sets the other expenses cost of the travel expense.
        /// </summary>
        [Column("other_expenses")]
        public decimal? OtherExpenses { get; set; } = 0;

        /// <summary>
        /// Gets or sets the total cost of the travel expense.
        /// </summary>
        [Column("total")]
        public decimal? Total { get; set; } = 0;

        // Unused Column
        /// <summary>
        /// Gets or sets the name of the travel expense.
        /// </summary>
        [Column("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the disclosure group of the travel expense.
        /// </summary>
        [Column("disclosure_group")]
        public string? DisclosureGroup { get; set; }

        /// <summary>
        /// Gets or sets the title (France) of the travel expense.
        /// </summary>
        [Column("title_fr")]
        public string? TitleFr { get; set; }

        /// <summary>
        /// Gets or sets the purpose (France) of the travel expense.
        /// </summary>
        [Column("purpose_fr")]
        public string? PurposeFr { get; set; }

        /// <summary>
        /// Gets or sets the destination (English) of the travel expense.
        /// </summary>
        [Column("destination_en")]
        public string? DestinationEn { get; set; }

        /// <summary>
        /// Gets or sets the destination (France) of the travel expense.
        /// </summary>
        [Column("destination_fr")]
        public string? DestinationFr { get; set; }

        /// <summary>
        /// Gets or sets the additional comments (English) of the travel expense.
        /// </summary>
        [Column("additional_comments_en")]
        public string? CommentsEn { get; set; }

        /// <summary>
        /// Gets or sets the additional comments (France) of the travel expense.
        /// </summary>
        [Column("additional_comments_fr")]
        public string? CommentsFr { get; set; }

        /// <summary>
        /// Gets or sets the owner organization of the travel expense.
        /// </summary>
        [Column("owner_org")]
        public string? OwnerOrg { get; set; }

        /// <summary>
        /// Gets or sets the owner organization title of the travel expense.
        /// </summary>
        [Column("owner_org_title")]
        public string? OwnerOrgTitle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelExpensesDTO"/> class.
        /// </summary>
        public TravelExpensesEntity() { }

    }
}
