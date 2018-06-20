using School2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School2.ModelView
{
	public class GetClasses {
		public IEnumerable<Class> Classes { get; set; }
		public Student Student { get; set; }

	}
}