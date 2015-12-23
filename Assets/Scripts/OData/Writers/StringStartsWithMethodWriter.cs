// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringStartsWithMethodWriter.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the StringStartsWithMethodWriter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2Rest.Provider.Writers
{
	using System;
    ////using System.Diagnostics.Contracts;
	using System.Linq.Expressions;

	internal class StringStartsWithMethodWriter : IMethodCallWriter
	{
		public bool CanHandle(MethodCallExpression expression)
		{
			//Contract.Assert(expression.Method != null);

			return expression.Method.DeclaringType == typeof(string)
				   && expression.Method.Name == "StartsWith";
		}

		public string Handle(MethodCallExpression expression, Func<Expression, string> expressionWriter)
		{
			//Contract.Assume(expression.Arguments.Count > 0);

			var argumentExpression = expression.Arguments[0];
			var obj = expression.Object;

			//Contract.Assume(obj != null);
			//Contract.Assume(argumentExpression != null);

			return string.Format(
				"startswith({0}, {1})", 
				expressionWriter(obj), 
				expressionWriter(argumentExpression));
		}
	}
}