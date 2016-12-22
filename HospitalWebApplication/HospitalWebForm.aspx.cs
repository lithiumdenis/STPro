using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;


namespace HospitalWebApplication
{
    public partial class HospitalWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        #region Reception methods

        //Изменение записей в Reception
        [WebMethod(EnableSession = true)]
        public static object UpdateReception(Reception record)
        {
            try
            {
                //using context and LINQ
                using (var ctx = new HospitalDatabaseEntities())
                {
                    var foundReception = ctx.Reception.FirstOrDefault(s => s.Id == record.Id);
                    if (foundReception == null)
                    {
                        throw new Exception("Запись не найдена!");
                    }

                    foundReception.Doctor_Id = record.Doctor_Id;
                    foundReception.Patient_Id = record.Patient_Id;
                    foundReception.Date = record.Date;
           
                    ctx.SaveChanges(); //Иначе ничего не сохраняет в БД из контекста
                }

                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Добавление записей в Reception
        [WebMethod(EnableSession = true)]
        public static object CreateReception(Reception record)
        {
            try
            {
                //using context and LINQ
                using (var ctx = new HospitalDatabaseEntities())
                {
                    ctx.Reception.Add(record);
                    ctx.SaveChanges(); //Иначе ничего не сохраняет в БД из контекста
                }

                return new { Result = "OK", Record = record };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Удаление записей из Reception
        [WebMethod(EnableSession = true)]
        public static object DeleteReception(int Id)
        {
            try
            {
                //using context and LINQ
                using (var ctx = new HospitalDatabaseEntities())
                {
                    //Выглядит странно, но это так и делается
                    Reception deleteThis = new Reception() { Id = Id };
                    ctx.Reception.Attach(deleteThis);
                    ctx.Reception.Remove(deleteThis);

                    ctx.SaveChanges(); //Иначе ничего не сохраняет в БД из контекста
                }

                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Чтение записей из Patient
        [WebMethod(EnableSession = true)]
        public static object ReceptionList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                //Get data from database
                int receptionCount = returnCountOfReceptions();
                List<Reception> receptions = returnPartOfReceptionsWithSorting(jtStartIndex, jtPageSize, jtSorting);

                //Return result to jTable
                return new { Result = "OK", Records = receptions, TotalRecordCount = receptionCount };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        private static List<Reception> returnPartOfReceptionsWithSorting(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            //int counterForTakeAPart = 0;
            List<Reception> mylist = new List<Reception>();

            //Это работает, но громоздко, мягко говоря. Зато context и LINQ
            using (var ctx = new HospitalDatabaseEntities())
            {
                var query = from a in ctx.Reception select a;

                // Сортировка

                //sort by Doctor_Id
                if (string.IsNullOrEmpty(jtSorting) || jtSorting.Equals("Doctor_Id ASC"))
                {
                    query = query.OrderBy(p => p.Doctor_Id);
                }
                else if (jtSorting.Equals("Doctor_Id DESC"))
                {
                    query = query.OrderByDescending(p => p.Doctor_Id);
                }

                //sort by Patient_Id
                else if(string.IsNullOrEmpty(jtSorting) || jtSorting.Equals("Patient_Id ASC"))
                {
                    query = query.OrderBy(p => p.Patient_Id);
                }
                else if (jtSorting.Equals("Patient_Id DESC"))
                {
                    query = query.OrderByDescending(p => p.Patient_Id);
                }

                //sort by Id
                else if(string.IsNullOrEmpty(jtSorting) || jtSorting.Equals("Id ASC"))
                {
                    query = query.OrderBy(p => p.Id);
                }
                else if (jtSorting.Equals("Id DESC"))
                {
                    query = query.OrderByDescending(p => p.Id);
                }

                //sort by Date
                else if(string.IsNullOrEmpty(jtSorting) || jtSorting.Equals("Date ASC"))
                {
                    query = query.OrderBy(p => p.Date);
                }
                else if (jtSorting.Equals("Date DESC"))
                {
                    query = query.OrderByDescending(p => p.Date);
                }

                //Default
                else
                {
                    query = query.OrderBy(p => p.Date);
                }

                var result = query.Skip(jtStartIndex).Take(jtPageSize).ToList(); //Paging

                //Иначе некорректная связь с Reception генерируется. Пересоздаём
                for (int i = 0; i < result.Count; i++)
                    mylist.Add(new Reception
                    {
                        Id = result[i].Id,
                        Patient_Id = result[i].Patient_Id,
                        Doctor_Id = result[i].Doctor_Id,
                        Date = result[i].Date
                    });

                return mylist;
            }
        }

        private static int returnCountOfReceptions()
        {
            int CountOfReceptions = 0;

            //using context and LINQ
            using (var ctx = new HospitalDatabaseEntities())
            {
                CountOfReceptions = ctx.Reception.Count();
            }

            return CountOfReceptions;
        }

        #endregion

        #region Patient methods

        //Изменение записей в Patient
        [WebMethod(EnableSession = true)]
        public static object UpdatePatient(Patient record)
        {
            try
            {
                //using context and LINQ
                using (var ctx = new HospitalDatabaseEntities())
                {
                    var foundPatient = ctx.Patient.FirstOrDefault(s => s.Id == record.Id);
                    if (foundPatient == null)
                    {
                        throw new Exception("Запись не найдена!");
                    }

                    foundPatient.Surname = record.Surname;
                    foundPatient.Name = record.Name;
                    foundPatient.Age = record.Age;
                    foundPatient.Gender = record.Gender;
                    foundPatient.Contraindications = record.Contraindications;

                    ctx.SaveChanges(); //Иначе ничего не сохраняет в БД из контекста
                }

                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Добавление записей в Patient
        [WebMethod(EnableSession = true)]
        public static object CreatePatient(Patient record)
        {
            try
            {
                //using context and LINQ
                using (var ctx = new HospitalDatabaseEntities())
                {
                    ctx.Patient.Add(record);
                    ctx.SaveChanges(); //Иначе ничего не сохраняет в БД из контекста
                }

                return new { Result = "OK", Record = record };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Удаление записей из Patient
        [WebMethod(EnableSession = true)]
        public static object DeletePatient(int Id)
        {
            try
            {
                //using context and LINQ
                using (var ctx = new HospitalDatabaseEntities())
                {
                    //Выглядит странно, но это так и делается
                    Patient deleteThis = new Patient() { Id = Id };
                    ctx.Patient.Attach(deleteThis);
                    ctx.Patient.Remove(deleteThis);

                    ctx.SaveChanges(); //Иначе ничего не сохраняет в БД из контекста
                }

                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Чтение записей из Patient
        [WebMethod(EnableSession = true)]
        public static object PatientList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                //Get data from database
                int patientCount = returnCountOfPatients();
                List<Patient> patients = returnPartOfPatientsWithSorting(jtStartIndex, jtPageSize, jtSorting);

                //Return result to jTable
                return new { Result = "OK", Records = patients, TotalRecordCount = patientCount };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        private static List<Patient> returnPartOfPatientsWithSorting(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            //int counterForTakeAPart = 0;
            List<Patient> mylist = new List<Patient>();

            //Это работает, но громоздко, мягко говоря. Зато context и LINQ
            using (var ctx = new HospitalDatabaseEntities())
            {
                var query = from a in ctx.Patient select a;

                // Сортировка

                //sort by name
                if (string.IsNullOrEmpty(jtSorting) || jtSorting.Equals("Name ASC"))
                {
                    query = query.OrderBy(p => p.Name);
                }
                else if (jtSorting.Equals("Name DESC"))
                {
                    query = query.OrderByDescending(p => p.Name);
                }

                //sort by gender
                else if (jtSorting.Equals("Gender ASC"))
                {
                    query = query.OrderBy(p => p.Gender);
                }
                else if (jtSorting.Equals("Gender DESC"))
                {
                    query = query.OrderByDescending(p => p.Gender);
                }

                //sort by surname
                else if (jtSorting.Equals("Surname ASC"))
                {
                    query = query.OrderBy(p => p.Surname);
                }
                else if (jtSorting.Equals("Surname DESC"))
                {
                    query = query.OrderByDescending(p => p.Surname);
                }

                //sort by id
                else if (jtSorting.Equals("Id ASC"))
                {
                    query = query.OrderBy(p => p.Id);
                }
                else if (jtSorting.Equals("Id DESC"))
                {
                    query = query.OrderByDescending(p => p.Id);
                }

                //sort by age
                else if (jtSorting.Equals("Age ASC"))
                {
                    query = query.OrderBy(p => p.Age);
                }
                else if (jtSorting.Equals("Age DESC"))
                {
                    query = query.OrderByDescending(p => p.Age);
                }

                //sort by position
                else if (jtSorting.Equals("Contraindications ASC"))
                {
                    query = query.OrderBy(p => p.Contraindications);
                }
                else if (jtSorting.Equals("Contraindications DESC"))
                {
                    query = query.OrderByDescending(p => p.Contraindications);
                }

                //Default
                else
                {
                    query = query.OrderBy(p => p.Surname);
                }

                var result = query.Skip(jtStartIndex).Take(jtPageSize).ToList(); //Paging

                //Иначе некорректная связь с Reception генерируется. Пересоздаём
                for (int i = 0; i < result.Count; i++)
                    mylist.Add(new Patient
                    {
                        Age = result[i].Age,
                        Gender = result[i].Gender,
                        Id = result[i].Id,
                        Name = result[i].Name,
                        Contraindications = result[i].Contraindications,
                        Surname = result[i].Surname
                    });

                return mylist;
            }
        }

        private static int returnCountOfPatients()
        {
            int CountOfPatients = 0;

            //using context and LINQ
            using (var ctx = new HospitalDatabaseEntities())
            {
                CountOfPatients = ctx.Patient.Count();
            }

            return CountOfPatients;
        }

        #endregion

        #region Doctor methods

        //Изменение записей в Doctor
        [WebMethod(EnableSession = true)]
        public static object UpdateDoctor(Doctor record)
        {
            try
            {
                //using context and LINQ
                using (var ctx = new HospitalDatabaseEntities())
                {
                    var foundDoctor = ctx.Doctor.FirstOrDefault(s => s.Id == record.Id);
                    if(foundDoctor == null)
                    {
                        throw new Exception("Запись не найдена!");
                    }

                    foundDoctor.Surname = record.Surname;
                    foundDoctor.Name = record.Name;
                    foundDoctor.Age = record.Age;
                    foundDoctor.Gender = record.Gender;
                    foundDoctor.Position = record.Position;

                    ctx.SaveChanges(); //Иначе ничего не сохраняет в БД из контекста
                }
                
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Добавление записей в Doctor
        [WebMethod(EnableSession = true)]
        public static object CreateDoctor(Doctor record)
        {
            try
            {
                //using context and LINQ
                using (var ctx = new HospitalDatabaseEntities())
                {
                    ctx.Doctor.Add(record);
                    ctx.SaveChanges(); //Иначе ничего не сохраняет в БД из контекста
                }

                return new { Result = "OK", Record = record };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Удаление записей из Doctor
        [WebMethod(EnableSession = true)]
        public static object DeleteDoctor(int Id)
        {
            try
            {
                //using context and LINQ
                using (var ctx = new HospitalDatabaseEntities())
                {
                    //Выглядит странно, но это так и делается
                    Doctor deleteThis = new Doctor() { Id = Id };
                    ctx.Doctor.Attach(deleteThis);
                    ctx.Doctor.Remove(deleteThis);

                    ctx.SaveChanges(); //Иначе ничего не сохраняет в БД из контекста
                }

                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Чтение записей из Doctor
        [WebMethod(EnableSession = true)]
        public static object DoctorList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                //Get data from database
                int doctorCount = returnCountOfDoctors(); 
                List<Doctor> doctors = returnPartOfDoctorsWithSorting(jtStartIndex, jtPageSize, jtSorting);

                //Return result to jTable
                return new { Result = "OK", Records = doctors, TotalRecordCount = doctorCount };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Чтение страницы с сортировкой из Doctor
        private static List<Doctor> returnPartOfDoctorsWithSorting(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            List<Doctor> mylist = new List<Doctor>();

            //Это работает, но громоздко, мягко говоря. Зато context и LINQ
            using (var ctx = new HospitalDatabaseEntities())
            {
                var query = from a in ctx.Doctor select a;

                // Сортировка

                //sort by name
                if (string.IsNullOrEmpty(jtSorting) || jtSorting.Equals("Name ASC"))
                {
                    query = query.OrderBy(p => p.Name);
                }
                else if (jtSorting.Equals("Name DESC"))
                {
                    query = query.OrderByDescending(p => p.Name);
                }

                //sort by gender
                else if (jtSorting.Equals("Gender ASC"))
                {
                    query = query.OrderBy(p => p.Gender);
                }
                else if (jtSorting.Equals("Gender DESC"))
                {
                    query = query.OrderByDescending(p => p.Gender);
                }

                //sort by surname
                else if (jtSorting.Equals("Surname ASC"))
                {
                    query = query.OrderBy(p => p.Surname);
                }
                else if (jtSorting.Equals("Surname DESC"))
                {
                    query = query.OrderByDescending(p => p.Surname);
                }

                //sort by id
                else if (jtSorting.Equals("Id ASC"))
                {
                    query = query.OrderBy(p => p.Id);
                }
                else if (jtSorting.Equals("Id DESC"))
                {
                    query = query.OrderByDescending(p => p.Id);
                }

                //sort by age
                else if (jtSorting.Equals("Age ASC"))
                {
                    query = query.OrderBy(p => p.Age);
                }
                else if (jtSorting.Equals("Age DESC"))
                {
                    query = query.OrderByDescending(p => p.Age);
                }

                //sort by position
                else if (jtSorting.Equals("Position ASC"))
                {
                    query = query.OrderBy(p => p.Position);
                }
                else if (jtSorting.Equals("Position DESC"))
                {
                    query = query.OrderByDescending(p => p.Position);
                }

                //Default
                else
                {
                    query = query.OrderBy(p => p.Surname);
                }

                var result = query.Skip(jtStartIndex).Take(jtPageSize).ToList(); //Paging

                //Иначе некорректная связь с Reception генерируется. Пересоздаём
                for (int i = 0; i < result.Count; i++)
                    mylist.Add(new Doctor
                    {
                        Age = result[i].Age,
                        Gender = result[i].Gender,
                        Id = result[i].Id,
                        Name = result[i].Name,
                        Position = result[i].Position,
                        Surname = result[i].Surname
                    });

                return mylist;
            }
        }

        //Количество Doctor в таблице
        private static int returnCountOfDoctors()
        {
            int CountOfDoctors = 0;

            //using context and LINQ
            using (var ctx = new HospitalDatabaseEntities())
            {
                CountOfDoctors = ctx.Doctor.Count();
            }

            return CountOfDoctors;
        }

        #endregion
    }
}