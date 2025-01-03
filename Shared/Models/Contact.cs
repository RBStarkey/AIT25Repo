﻿using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared
{
    public class Contact
    {
        [JsonProperty(PropertyName = "id")]
        [DisplayName("ID")]
        public Guid Id { get; set; }

        [DisplayName("Contact Name")]
        [Required]
        [StringLength(64, ErrorMessage = "Contact Name is too long. (Max chars: 64)")]
        public string ContactName { get; set; }

        [DisplayName("Job Description")]
        [Required]
        [StringLength(64, ErrorMessage = "Job Description is too long. (Max chars: 64)")]
        public string JobDescription { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        [StringLength(256, ErrorMessage = "Email is too long. (Max chars: 256)")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not well formed")]
        public string Email { get; set; }

        [DisplayName("Telephone Extension")]
        [Required]
        [StringLength(4, ErrorMessage = "Telephone Extension is too long. (Max chars: 4)")]
        public string Extension { get; set; }

        [DisplayName("Mobile")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [DisplayName("Department")]
        [Required]
        [StringLength(64, ErrorMessage = "Department is too long. (Max chars: 64)")]
        public string Department { get; set; }	= string.Empty;
		public bool IsVisible { get; set; }
        public bool IsSelected { get; set; }

		public string SearchString { get; set; } = string.Empty;

		public void LoadSearchString()
		{
			SearchString += ContactName == string.Empty?"":ContactName;
			SearchString += JobDescription == string.Empty ? "" : JobDescription;
			SearchString += Email == string.Empty ? "" : Email;
			SearchString += Extension == string.Empty ? "" : Extension;
			SearchString += Department == string.Empty ? "" : Department;
			SearchString += Mobile == string.Empty ? "" : Mobile;
		}
	}
}
