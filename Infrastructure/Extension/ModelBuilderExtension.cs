using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extension
{
    internal static class ModelBuilderExtension
    {
        internal static void ApplyAllConfiguration(this ModelBuilder modelBuilder)
        {
            var typeToRegister = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType &&
                                gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();
            foreach (var type in typeToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type) ??
                                                throw new InvalidOperationException($"Unable to instance type {type.FullName}");
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

        }
    }
}
