using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHouse.Models.Utils
{
	public class Status
	{
		public const string Pending = "Pending";
		public const string Approved = "Approved";
		public const string InProcess = "InProcessing";
		public const string Shipped = "Shipped";
		public const string Canceled = "Canceled";
		public const string Refused = "Refused";

		public const string PaymentPending = "Pending";
		public const string PaymentApproved = "Approved";
		public const string PaymentRejected = "Rejected";
	}
}
