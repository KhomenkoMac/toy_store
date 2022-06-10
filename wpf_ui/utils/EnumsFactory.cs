using BuisnessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace wpf_ui.utils
{
    // Fltweight
    public class EnumsFactory
    {
        private static Dictionary<Type, IEnumerable<Enum>> _enums = new Dictionary<Type, IEnumerable<Enum>>();

        private static IEnumerable<Enum> CastToEnum<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<Enum>();
        }

        public static IEnumerable<Rate> CreateRateEnumsColleciton()
        {
            if (!_enums.ContainsKey(typeof(Rate)))
            {
                _enums.Add(typeof(Rate), CastToEnum<Rate>());
            }

            return _enums[typeof(Rate)].Cast<Rate>();
        }

        public static IEnumerable<Role> CreateRolesEnumColleciton()
        {
            if (!_enums.ContainsKey(typeof(Role)))
            {
                _enums.Add(typeof(Role), CastToEnum<Role>());
            }

            return _enums[typeof(Role)].Cast<Role>();
        }

        public static IEnumerable<Subject> CreateSubjectsEnumColleciton()
        {
            if (!_enums.ContainsKey(typeof(Subject)))
            {
                _enums.Add(typeof(Subject), CastToEnum<Subject>());
            }

            return _enums[typeof(Subject)].Cast<Subject>();
        }
    }
}
