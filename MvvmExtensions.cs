using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.ComponentModel;

namespace LambdaPropertyPerformanceApp
{
    //combination of these blog posts (and comments):
    //http://www.jphamilton.net/post/MVVM-with-Type-Safe-INotifyPropertyChanged.aspx
    //http://blog.decarufel.net/2009/07/how-to-use-inotifypropertychanged-type_22.html
    //http://consultingblogs.emc.com/merrickchaffer/archive/2010/01/22/a-simple-implementation-of-inotifypropertychanged.aspx
    public static class MvvmExtensions
    {
        public static void Raise(this PropertyChangedEventHandler handler, object sender, Expression<Func<object>> expression)
        {
            if (handler != null)
            {
                if (expression.NodeType != ExpressionType.Lambda)
                {
                    throw new ArgumentException("Value must be a lamda expression", "expression");
                }

                var body = expression.Body as MemberExpression;

                if (body == null)
                {
                    throw new ArgumentException("'x' should be a member expression");
                }

                string propertyName = body.Member.Name;
                handler(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
