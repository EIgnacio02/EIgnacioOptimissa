using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cuenta
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioOptimissaContext context= new DL.EignacioOptimissaContext())
                {
                    var query = context.Cuenta.FromSqlRaw("CuentaGetAll").ToList();
                    result.ObjectsList = new List<object>();

                    if (query !=null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Cuenta cuenta = new ML.Cuenta();

                            cuenta.account = obj.Account;
                            cuenta.balance = (int)obj.Balance;
                            cuenta.Owners = obj.Owners;
                            cuenta.Fecha= (DateTime)obj.Fecha;

                            result.ObjectsList.Add(cuenta);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }
        public static ML.Result GetById(string Account)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioOptimissaContext context = new DL.EignacioOptimissaContext())
                {
                    var query = context.Cuenta.FromSqlRaw($"CuentaGetById {Account}").AsEnumerable().SingleOrDefault();

                    result.ObjectsList = new List<object>();

                    if (query!=null)
                    {
                        ML.Cuenta cuenta = new ML.Cuenta();

                        cuenta.account = query.Account;
                        cuenta.balance = (int)query.Balance;
                        cuenta.Owners = query.Owners;
                        cuenta.Fecha = (DateTime)query.Fecha;

                        result.Object = cuenta;

                    }
                }
                result.Correct= true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public static ML.Result Add(ML.Cuenta cuenta)
        {
            ML.Result result= new ML.Result();

            try
            {
                using (DL.EignacioOptimissaContext context= new DL.EignacioOptimissaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"CuentaAdd '{cuenta.account}',{cuenta.balance},'{cuenta.Owners}'");
                    result.ObjectsList= new List<object>();

                    if (query>0)
                    {
                        result.Message = "Se ingresaron los registros correctamente";
                    }
                }
                result.Correct= true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}
