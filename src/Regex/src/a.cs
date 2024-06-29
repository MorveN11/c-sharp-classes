   public static class RegexExtension
    {
        public static string GetString<T>(T value)
        {
            if (value is null)
            {
                return null;
            }
            return value.ToString();
        }

        public static Func<string> Close<T>(T value)
        {
            int counter = 0;

            return () =>
            {
                var result = String.Empty;

                for (int i = 0; i < counter; i++)
                {
                    result += value;
                }
                counter++;
                return result;
            };
        }

        public static string GetString(this HashSet<string> values)
        {
            string result = String.Empty;
            foreach (var item in values)
            {
                result += item + ",";
            }

            return result.TrimEnd(',');
        }

        public static HashSet<string> UnionHashSet(this HashSet<string> value, HashSet<string> value2)
        {
            var union = new HashSet<string>();

            foreach (var c in value) union.Add(c);
            foreach (var c in value2) union.Add(c);
            return union;
        }
        public static HashSet<string> Concatenate(this HashSet<string> value, HashSet<string> value2)
        {
            HashSet<string> result = new HashSet<string>();
            foreach (var item in value)
            {
                foreach (var item2 in value2)
                {
                    result.Add(item + item2);
                }
            }
            return result;
        }

        public static Func<HashSet<string>> CloserSet(this HashSet<string> value)
        {
            int counter = 0;
            HashSet<string> result = new HashSet<string>();
            return () =>
            {
                if (counter == 0)
                {
                    result.Add(string.Empty);
                }
                else
                {
                    var temp = new List<string>(result);
                    foreach (var item in value)
                    {
                        if (temp.Count == 0)
                        {
                            temp.Add(item);
                        }
                        else
                        {
                            var newTemp = new List<string>();
                            foreach (var t in temp)
                            {
                                newTemp.Add(t + item);
                            }
                            temp.AddRange(newTemp);
                        }
                    }
                    foreach (var t in temp)
                    {
                        result.Add(t);
                    }
                }
                counter++;
                return new HashSet<string>(result);
            };
        }
        public static HashSet<string> Concatenate<T>(this HashSet<T> set, string primitive)
        {
            var result = new HashSet<string>();
            foreach (var item in set)
            {
                result.Add($"{item}{primitive}");
            }

            return result;
        }

        public static (Func<HashSet<string>> ClosureFunc, Func<bool, HashSet<string>> ConcatFunc) FormRegex(string pattern)
        {
            var parts = pattern.Split('·');
            var prefix = parts[0];
            var suffix = parts.Length > 1 ? parts[1] : "";

            var prefixGroups = new List<HashSet<string>>();
            var currentGroup = new HashSet<string> { "" };

            foreach (var c in prefix)
            {
                if (c == '(')
                {
                    prefixGroups.Add(currentGroup);
                    currentGroup = new HashSet<string>();
                }
                else if (c == ')')
                {
                    var group = prefixGroups[prefixGroups.Count - 1];
                    prefixGroups.RemoveAt(prefixGroups.Count - 1);
                    group = group.CloserSet()();
                    if (prefixGroups.Count > 0)
                    {
                        prefixGroups[prefixGroups.Count - 1] = prefixGroups[prefixGroups.Count - 1].Concatenate(group);
                    }
                    else
                    {
                        currentGroup = group;
                    }
                }
                else if (c == '+')
                {
                    currentGroup = currentGroup.UnionHashSet(new HashSet<string> { "" });
                }
                else if (c == '*')
                {
                    currentGroup = currentGroup.CloserSet()();
                }
                else
                {
                    currentGroup = currentGroup.Concatenate(c.ToString());
                }
            }

            var closureFunc = currentGroup.CloserSet();
            var concatFunc = (bool concat) => concat ? closureFunc().Concatenate(suffix) : closureFunc();

            return (closureFunc, concatFunc);
        }

        public static bool IsMatch(this (Func<HashSet<string>> ClosureFunc, Func<bool, HashSet<string>> ConcatFunc) formRegex, string input)
        {
            var matchingStrings = formRegex.ConcatFunc(true);
            return matchingStrings.Contains(input);
        }

        //----------------------------------------------------------------------------
        public static bool IsValidDate(string date)
        {
            string[] parts = date.Split('/');
            if (parts.Length != 3)
                return false;

            int day, year;
            string month;

            if (!int.TryParse(parts[0], out day) || day < 1 || day > 31)
                return false;

            month = parts[1];
            if (!IsValidMonth(month))
                return false;

            if (!int.TryParse(parts[2], out year) || year < 1800 || year > 3000)
                return false;

            if (month == "Febrero" && day > 28 && !IsLeapYear(year))
                return false;

            if ((month == "Abril" || month == "Junio" || month == "Septiembre" || month == "Noviembre") && day > 30)
                return false;

            return true;
        }

        private static bool IsValidMonth(string month)
        {
            var months = new HashSet<string> { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            return months.Contains(month);
        }

        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }

        public static bool IsValidEmail(string email)
        {
            string[] parts = email.Split('@');
            if (parts.Length != 2)
                return false;

            string username = parts[0];
            string domain = parts[1];

            if (string.IsNullOrWhiteSpace(username) || !IsValidUsername(username))
                return false;

            if (!IsValidDomain(domain))
                return false;

            return true;
        }

        private static bool IsValidUsername(string username)
        {
            var closureFunc = RegexExtension.FormRegex("(a+b*c*d*e*f*g*h*i*j*k*l*m*n*o*p*q*r*s*t*u*v*w*x*y*z*A*B*C*D*E*F*G*H*I*J*K*L*M*N*O*P*Q*R*S*T*U*V*W*X*Y*Z*0*1*2*3*4*5*6*7*8*9*_.)").ClosureFunc;
            var matchingStrings = closureFunc();
            return matchingStrings.Contains(username);
        }

        private static bool IsValidDomain(string domain)
        {
            string[] parts = domain.Split('.');
            if (parts.Length != 2)
                return false;

            string domainName = parts[0];
            string extension = parts[1];

            var validDomainNames = new HashSet<string> { "gmail", "yahoo", "outlook" };
            var validExtensions = new HashSet<string> { "com", "org", "bo" };

            return validDomainNames.Contains(domainName) && validExtensions.Contains(extension);
        }
    }
}
