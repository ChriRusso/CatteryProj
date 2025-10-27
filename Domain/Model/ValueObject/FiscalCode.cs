    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    namespace Domain.Model.ValueObject
    {
        public sealed record class FiscalCode
        {
            public string Value { get; }

            public FiscalCode(string Cod)
            {
                if (string.IsNullOrWhiteSpace(Cod))
                    throw new ArgumentException("Il codice fiscale non può essere vuoto.", nameof(Cod));

                if(!IsValid(Cod))
                    throw new ArgumentException("Il codice fiscale non è valido.", nameof(Cod));
            Value = Cod;
        }

        public static bool IsValid(string cf)
        {
            if (string.IsNullOrWhiteSpace(cf))
                return false;

            var s = cf.Trim().ToUpperInvariant();

            // 6 lettere, 2 cifre, 1 lettera, 2 cifre, 1 lettera, 3 cifre, 1 lettera
            return Regex.IsMatch(s, @"^[A-Z]{6}\d{2}[A-Z]\d{2}[A-Z]\d{3}[A-Z]$");
        }

    }
}
