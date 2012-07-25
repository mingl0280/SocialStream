﻿using System;
using System.Globalization;
using System.Windows.Controls;

namespace SocialStream.ConfigTool.Validators
{
    /// <summary>
    /// A validation rule for a hex number.
    /// </summary>
    public class IsValidDateTimeValueRule : ValidationRule
    {
        /// <summary>
        /// When overridden in a derived class, performs validation checks on a value.
        /// </summary>
        /// <param name="value">The value from the binding target to check.</param>
        /// <param name="cultureInfo">The culture to use in this rule.</param>
        /// <returns>
        /// A <see cref="T:System.Windows.Controls.ValidationResult"/> object.
        /// </returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string val = value as string;

            if (val == null || string.IsNullOrWhiteSpace(val))
            {
                return new ValidationResult(false, SocialStream.ConfigTool.Properties.Resources.DateTimeError);
            }

            DateTime parsed;
            if (DateTime.TryParse(val, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, SocialStream.ConfigTool.Properties.Resources.DateTimeError);
            }
        }
    }
}
