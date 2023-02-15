using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Transferencia
    {
        public static ML.Result Add(ML.Tranferencia tranferencia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioOptimissaContext context=new DL.EignacioOptimissaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"Transferencia '{tranferencia.FromAccount}','{tranferencia.ToAccount}',{tranferencia.Amount} ");
                    result.ObjectsList = new List<object>();

                    if (query>2)
                    {
                        result.Message = "Se registraron los campos correctamente";
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

        public static ML.Result TransactionGetByToAccount(string ToAccount)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EignacioOptimissaContext context = new DL.EignacioOptimissaContext())
                {
                    var query = context.Tranferencia.FromSqlRaw($"TransactionGetByToAccount '{ToAccount}'").ToList();
                    result.ObjectsList=new List<object>();

                    if (query!=null)
                    {

                        foreach (var obj in query)
                        {
                            ML.Tranferencia tranferencia = new ML.Tranferencia();
                            tranferencia.FromAccount = obj.FromAccount;
                            tranferencia.ToAccount = obj.ToAccount;
                            tranferencia.Amount = (decimal)obj.Amount;
                            tranferencia.FechaEnvio = (DateTime)obj.FechaEnvio;

                            result.ObjectsList.Add(tranferencia);
                        }   
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }


        public static ML.Result TransactionGetByAccount()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EignacioOptimissaContext context = new DL.EignacioOptimissaContext())
                {
                    var query = context.Tranferencia.FromSqlRaw($"TransactionGetByAccount");
                    result.ObjectsList = new List<object>();

                    if (query != null)
                    {

                        foreach (var obj in query)
                        {
                            ML.Tranferencia tranferencia = new ML.Tranferencia();
                            tranferencia.FromAccount = obj.FromAccount;
                            tranferencia.ToAccount = obj.ToAccount;
                            tranferencia.Amount = (decimal)obj.Amount;
                            tranferencia.FechaEnvio = (DateTime)obj.FechaEnvio;

                            result.ObjectsList.Add(tranferencia);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
    }
}
