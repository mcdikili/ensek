using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.Models
{
    public class Settings
    {
        /// <summary>
        /// The base URL of the API.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// The username for authentication.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password for authentication.
        /// </summary>
        public string Password { get; set; }
    }
}
