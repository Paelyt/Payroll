using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayerT.DataManager
{
    public class DataWriter
    {
        static UvlotEntities uvDb = new UvlotEntities();



        public static int SaveBVNDetails(Helper.BVNC bvnc)
        {
            int i = 0;
            try
            {

                BanksManager bObj = new BanksManager
                {
                    BankName = bvnc.EnrollmentBank,
                    ContactAddress = bvnc.address,
                    DateOfBirth = bvnc.Dateofbirth,
                    EnrollmentBranch = bvnc.EnrollmentBranch,
                    Firstname = bvnc.FirstNAme,
                    Gender = bvnc.gender,
                    IsVisible = 1,
                    Lastname = bvnc.LastName,
                    Marital_Status = bvnc.marital_status,
                    Nationlaity = bvnc.Nationality,
                    Othernames = bvnc.MiddleName,
                    ValueDate = MyUtility.getCurrentLocalDateTime().ToString("yyyy/MM/dd"),
                    VerifiedStatus = bvnc.respCode == "00" ? 1 : 0,
                    ServiceResponse = bvnc.respDescription
                };
                uvDb.BanksManagers.Add(bObj);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message);
            }
            return i;
        }


        /*  public string InsertMonthlyRepaymentLog(Remitaresp resp)
          {
              try
              {
                  uvDb.RemitaResp.Add(resp);
                  uvDb.SaveChanges();
              }
              catch(Exception ex)
              {
                  WebLog.Log(ex.Message.ToString());
                  return null;
              }
          }
          */
        public string UpdateEmp(string id)
        {
            try
            {
                var ids = Convert.ToInt16(id);
                var i = 0;
                var RefNum = (from a in uvDb.LoanApplications where a.ID == ids select a.LoanRefNumber).FirstOrDefault();
                if (RefNum != null)
                {
                    var original = (from a in uvDb.LoanLedgers where a.RefNumber == RefNum && a.PaymentFlag_FK == 0 select a).ToList();
                    if (original.Count > 0)
                    {
                        for (i = 1; i == original.Count; i++)
                        {
                            original[i].Institution_FK = 7;

                            uvDb.SaveChanges();
                        }

                    }
                }
                return RefNum;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return null;
            }
        }

        public int LoanRepayment(int tenure, double RepayAmount, string ReferenceNum)
        {
            try
            {
                var i = 0;
                var original = (from a in uvDb.LoanLedgers
                                where a.RefNumber == ReferenceNum && a.Credit == 0
                                select a).ToList();
                if (original.Count > 0)
                {
                    for (i = 0; i <= tenure; i++)
                    {
                        for (i = 0; i <= original.Count; i++)
                        {
                            original[i].Credit = RepayAmount;
                            original[i].PaymentFlag_FK = 1;
                            uvDb.SaveChanges();
                        }
                    }
                }
                return original.Count;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;
            }
        }


        public int UpdateNYSCLoanReferalLeder(List<LoansLedger> Ln, double mode, double div)
        {
            try
            {
                var bn = 0;
                int nb = Ln.Count;
                for (var c = 0; c < nb; c++)
                {
                    int cv = Ln[c].ID;
                    var original = (from a in Ln where a.ID == cv select a).SingleOrDefault();

                    if (c + 1 == div && mode != 0)
                    {
                        original.Credit = mode;
                    }

                    else
                    {
                        original.Credit = original.Debit;
                    }
                    uvDb.SaveChanges();

                    bn = original.ID;
                }



                return bn;


            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;
            }
        }


        public PatnerTransactLog insertRemitaObj(PatnerTransactLog patnersLog)
        {
            try
            {

                uvDb.PatnerTransactLogs.Add(patnersLog);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message);
            }
            return patnersLog;
        }

        public Signature InsertSinature(Signature signature)
        {
            try
            {
                uvDb.Signatures.Add(signature);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message);
            }
            return signature;
        }
        public LoanApproval CreateLoanApproval(LoanApproval instObj)
        {
            try
            {

                uvDb.LoanApprovals.Add(instObj);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message);
            }
            return instObj;
        }

        public static Institution CreateIntitution(Institution instObj)
        {
            try
            {
                // uvDb= new UvlotEntities();
                uvDb.Institutions.Add(instObj);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message);
            }
            return instObj;
        }



        public static EmployerLoanDetail CreateEmployerLoanDetails(EmployerLoanDetail instObj)
        {
            try
            {
                // uvDb= new UvlotEntities();
                uvDb.EmployerLoanDetails.Add(instObj);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message);
            }
            return instObj;
        }


        public static StudentLoanDetail CreateStudentLoanDetails(StudentLoanDetail instObj)
        {
            try
            {
                uvDb.StudentLoanDetails.Add(instObj);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message);
            }
            return instObj;
        }

        public void InsertMonthlyRepaymentLog(MonthlyRepayment _MR)
        {
            try
            {


                uvDb.MonthlyRepayments.Add(_MR);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());

            }
        }


        public void UpdateRequestIDFromInitialDebit(string Refid, string reqID)
        {
            try
            {

                var original = (from a in uvDb.PatnerTransactLogs where a.RefNum == Refid && a.PatnerCode == "Remita" select a).FirstOrDefault();
                if (original != null)
                {

                    original.InitialDebitRequestId = reqID;

                    uvDb.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        public void UpdateUsers(User users)
        {
            try
            {
                // var original = uvDb.Users.Find(users.ID);
                var original = (from a in uvDb.Users where a.EmailAddress == users.EmailAddress select a).FirstOrDefault();
                if (original != null)
                {
                    // original.ResetPassword = users.ResetPassword;
                    //original.DateTim = users.DateTim;
                    original.Audit = users.Audit;
                    original.LastUpdated = users.LastUpdated;
                    uvDb.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }


        public LoanInterestRate CreateLoanInterestrate(LoanInterestRate instObj)
        {
            try
            {
                uvDb.LoanInterestRates.Add(instObj);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message);
            }
            return instObj;
        }
        public static LoanApplication CreateLoanApplication(LoanApplication loanObj)
        {
            try
            {
                // uvDb= new UvlotEntities();
                uvDb.LoanApplications.Add(loanObj);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message);
            }
            return loanObj;
        }


        public LoanLedger InsertLedgerTransact(string IDS, DateTime paymentDate, LoanLedger LoanLedger, LedgerTransact Lt, float Ampd, int instFk)
        {
            try
            {
                UvlotEntities uDb = new UvlotEntities();
                var ldger = uvDb.LoanLedgers.Find(LoanLedger.ID);


                var localDate = MyUtility.getCurrentLocalDateTime();
                var trx = uvDb.LedgerTransacts.Where(x => x.ReferenceNum == ldger.RefNumber &&
                x.Credit == Ampd && x.DatePaid == localDate.Date).FirstOrDefault();

                if (trx != null)
                {
                    return ldger;
                }
                instFk = instFk > 0 ? instFk : 7;

                int ID = Convert.ToInt32(IDS);
                LoanLedger.ID = ID;
                var resp = uvDb.LoanLedgers.Find(LoanLedger.ID);
                if (resp != null)
                {
                    Lt.colss = resp.ID;
                    Lt.cols = instFk;
                    if (Ampd == 0)
                    {
                        Lt.Credit = resp.Debit;
                    }
                    else
                    {
                        Lt.Credit = Ampd;
                    }
                    Lt.Debit = 0;
                    Lt.DueDate = resp.TranxDate;
                    Lt.DatePaid = paymentDate;
                    Lt.ReferenceNum = resp.RefNumber;
                    Lt.ValueDate = localDate.ToString("yyyy/MM/dd");
                    Lt.ValueTime = localDate.ToString("H:mm ss");
                    uvDb.LedgerTransacts.Add(Lt);
                    uvDb.SaveChanges();
                }
                /* int ID = Convert.ToInt32(IDS);
                 LoanLedger.ID = ID;
                 var resp = uvDb.LoanLedgers.Find(LoanLedger.ID);

                 if (resp != null)
                 {
                     resp.Credit = resp.Debit;
                     resp.PaymentFlag_FK = 1;
                     uvDb.SaveChanges();
                 }
                 return resp.ID;
                 */
                // return (double)resp.Debit;
                return resp;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return null;
            }
        }
        public LoanLedger InsertLedgerTransact(LoanLedger loanLedger)
        {
            try
            {
                UvlotEntities uDb = new UvlotEntities();
                var ldger = uvDb.LoanLedgers.Find(loanLedger.ID);


                var localDate = MyUtility.getCurrentLocalDateTime();
                var trx = uvDb.LedgerTransacts.Where(x => x.ReferenceNum == ldger.RefNumber &&
                x.Credit == loanLedger.Credit && x.DatePaid == loanLedger.TranxDate).FirstOrDefault();

                if (trx != null)
                {
                    return ldger;
                }
                LedgerTransact Lt = new LedgerTransact();

                Lt.colss = loanLedger.ID;
                Lt.cols = loanLedger.Institution_FK;
                Lt.Credit = loanLedger.Debit;
                Lt.Debit = 0;
                Lt.DueDate = loanLedger.TranxDate;
                Lt.DatePaid = loanLedger.TranxDate;
                Lt.ReferenceNum = loanLedger.RefNumber;
                Lt.ValueDate = localDate.ToString("yyyy/MM/dd");
                Lt.ValueTime = localDate.ToString("H:mm ss");
                uvDb.LedgerTransacts.Add(Lt);
                uvDb.SaveChanges();


                return loanLedger;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return null;
            }
        }

        public int LedgerTransact(string IDS, LoanLedger LoanLedger)
        {
            try
            {
                int ID = Convert.ToInt32(IDS);
                LoanLedger.ID = ID;
                var resp = uvDb.LoanLedgers.Find(LoanLedger.ID);

                if (resp != null)
                {
                    resp.Credit = resp.Debit;
                    resp.PaymentFlag_FK = 1;
                    uvDb.SaveChanges();
                }
                return resp.ID;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;
            }
        }


        public int UpdateLedger(string IDS, LoanLedger LoanLedger)
        {
            try
            {
                int ID = Convert.ToInt32(IDS);
                LoanLedger.ID = ID;
                var resp = uvDb.LoanLedgers.Find(LoanLedger.ID);

                if (resp != null)
                {
                    // resp.Credit = resp.Debit;
                    resp.Credit = LoanLedger.Credit;
                    resp.PaymentFlag_FK = LoanLedger.PaymentFlag_FK;
                    uvDb.SaveChanges();
                }
                return resp.ID;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;
            }
        }


        public int UpdateOrganisation(string IDS, int NewOrg)
        {
            try
            {
                int ID = Convert.ToInt32(IDS);

                var resp = (from a in uvDb.LoanApplications where a.ID == ID select a).FirstOrDefault();

                if (resp != null)
                {

                    resp.Institution_FK = NewOrg;

                    uvDb.SaveChanges();
                }
                return resp.ID;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;
            }
        }



        public int UpdateLedgers(string IDS, LoanLedger LoanLedger)
        {
            try
            {
                int ID = Convert.ToInt32(IDS);
                LoanLedger.ID = ID;
                var resp = uvDb.LoanLedgers.Find(LoanLedger.ID);

                if (resp != null)
                {
                    resp.Credit = LoanLedger.Debit;
                    resp.PaymentFlag_FK = LoanLedger.PaymentFlag_FK;
                    uvDb.SaveChanges();
                }
                return resp.ID;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;
            }
        }






        public static Guarantor CreateGuarantor(Guarantor instObj)
        {
            try
            {
                uvDb.Guarantors.Add(instObj);
                uvDb.SaveChanges();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message);
            }
            return instObj;
        }

        /*  public int InsertSignature(Signatures signature)
          {

              try
              {

                  uvDb.Signatures.Add(signature);
                  uvDb.SaveChanges();
                  return signature.ID;

              }

              catch (Exception ex)
              {
                  WebLog.Log(ex.Message.ToString());
                  return ex.Message.Count();

              }

          }
          */


        public int InsertUser(User user)
        {

            try
            {


                uvDb.Users.Add(user);
                uvDb.SaveChanges();
                return user.ID;

            }

            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return ex.Message.Count();

            }

        }


        public int InsertPatnerTransactLog(PatnerTransactLog pt)
        {

            try
            {


                uvDb.PatnerTransactLogs.Add(pt);
                uvDb.SaveChanges();
                return pt.ID;

            }

            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return ex.Message.Count();

            }

        }


        //public int InsertUserRoles(UserRole userrole)
        //{

        //    try
        //    {


        //        uvDb.UserRoles.Add(userrole);
        //        uvDb.SaveChanges();
        //        return userrole.ID;

        //    }

        //    catch (Exception ex)
        //    {
        //        WebLog.Log(ex.Message.ToString());
        //        return ex.Message.Count();

        //    }

        //}
        public int CreatePages(Page pages)
        {

            try
            {
                uvDb.Pages.Add(pages);
                uvDb.SaveChanges();

                return pages.PageID;

            }

            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;

            }

        }
        public int UpdateEmpInfo(EmployerLoanDetail EmpAp)
        {
            try
            {
                var original = (from a in uvDb.EmployerLoanDetails where a.LoanApplication_FK == EmpAp.ID select a).First();
                if (original.ID != 0)
                {
                    original.NetMonthlyIncome = EmpAp.NetMonthlyIncome;
                    original.Occupation = EmpAp.Occupation;
                    original.EmploymentStatus_FK = EmpAp.EmploymentStatus_FK;
                    original.EmployerID = EmpAp.EmployerID;
                    original.Department = EmpAp.Department;
                    original.Designation = EmpAp.Designation;
                    original.LengthOfServiceInYrs = EmpAp.LengthOfServiceInYrs;
                    original.OfficialEmailAddress = EmpAp.OfficialEmailAddress;
                    uvDb.SaveChanges();
                }
                return original.ID;

            }


            catch (Exception ex)
            {

                WebLog.Log(ex.Message.ToString());
                return 0;
            }

        }


        public int UpdateLoanApplication(DataAccessLayerT.Classes.LoanApplication LoanApp)
        {
            try
            {


                //uvDb.LoanApplications.Add(LoanApp);
                //uvDb.SaveChanges();

                //return LoanApplications.PageID;
                return 0;

            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;
            }
        }
        public int UpdateLoanApplication(LoanApplication LoanApp)
        {
            try
            {

                var original = uvDb.LoanApplications.Find(LoanApp.LoanRefNumber);


                if (original != null)
                {

                    original.ApplicationStatus_FK = LoanApp.ApplicationStatus_FK;
                    // original.LoanComment = LoanApp.LoanComment; 
                    original.DateModified = LoanApp.DateModified;

                    uvDb.SaveChanges();
                }
                return original.ID;

            }


            catch (Exception ex)
            {

                WebLog.Log(ex.Message.ToString());
                return 0;
            }

        }


        public int UpdateEmployeeInfo(EmployerLoanDetail LoanApp)
        {
            try
            {

                var EmpDetails = uvDb.EmployerLoanDetails.Find(LoanApp.LoanApplication_FK);
                if (EmpDetails != null)
                {

                    EmpDetails.Department = LoanApp.Department;
                    EmpDetails.Designation = LoanApp.Designation;
                    EmpDetails.EmployerID = LoanApp.EmployerID;
                    EmpDetails.EmploymentStatus_FK = LoanApp.EmploymentStatus_FK;
                    EmpDetails.NetMonthlyIncome = LoanApp.NetMonthlyIncome;
                    EmpDetails.OfficialEmailAddress = LoanApp.OfficialEmailAddress;
                    EmpDetails.LengthOfServiceInMth = LoanApp.LengthOfServiceInMth;
                    EmpDetails.Occupation = LoanApp.Occupation;

                    uvDb.SaveChanges();
                }
                return EmpDetails.ID;

            }
            catch (Exception ex)
            {

                WebLog.Log(ex.Message.ToString());
                return 0;
            }

        }
        public int UpdateMyLoanApplication(LoanApplication LoanApp)
        {
            try
            {

                var original = uvDb.LoanApplications.Find(LoanApp.LoanRefNumber);
                if (original != null)
                {

                    original.ApplicationStatus_FK = LoanApp.ApplicationStatus_FK;
                    // original.LoanComment = LoanApp.LoanComment; 
                    original.DateModified = LoanApp.DateModified;

                    original.Institution_FK = LoanApp.Institution_FK;
                    //LoanApps.MeansOfIDFilePath = LoanApp.ValueTime;
                    original.AccomodationType_FK = LoanApp.AccomodationType_FK;
                    original.AccountName = LoanApp.AccountName;
                    original.AccountNumber = LoanApp.AccountNumber;
                    original.ApplicantID = LoanApp.ApplicantID;
                    original.ApplicationStatus_FK = LoanApp.ApplicationStatus_FK;
                    original.BankCode = Convert.ToString(LoanApp.BankCode);
                    original.BVN = LoanApp.BVN;
                    original.ClosestBusStop = LoanApp.ClosestBusStop;
                    original.ContactAddress = LoanApp.ContactAddress;
                    //LoanApps.CreatedBy = LoanApp.CreatedBy; //Change To User ID
                    original.DateCreated = LoanApp.DateCreated;
                    original.DateModified = LoanApp.DateModified;
                    original.DateOfBirth = Convert.ToString(LoanApp.DateOfBirth);
                    original.EmailAddress = LoanApp.EmailAddress;
                    original.ExistingLoan = LoanApp.ExistingLoan;
                    original.ExistingLoan_NoOfMonthsLeft = LoanApp.ExistingLoan_NoOfMonthsLeft;
                    original.ExistingLoan_OutstandingAmount = LoanApp.ExistingLoan_OutstandingAmount;
                    original.Firstname = LoanApp.Firstname;
                    original.Gender_FK = LoanApp.Gender_FK;
                    original.IdentficationNumber = LoanApp.IdentficationNumber;
                    original.Landmark = LoanApp.Landmark;
                    original.LGA_FK = LoanApp.LGA_FK;
                    original.LoanAmount = LoanApp.LoanAmount;
                    original.LoanComment = "";
                    original.LoanRefNumber = LoanApp.LoanRefNumber;
                    original.LoanTenure = LoanApp.LoanTenure;
                    original.MaritalStatus_FK = LoanApp.MaritalStatus_FK;
                    original.MeansOfID_FK = LoanApp.MeansOfID_FK;
                    original.NOK_EmailAddress = LoanApp.NOK_EmailAddress;
                    original.NOK_FullName = LoanApp.NOK_FullName;
                    original.NOK_HomeAddress = LoanApp.NOK_HomeAddress;
                    original.NOK_PhoneNumber = LoanApp.NOK_PhoneNumber;
                    original.NOK_Relationship = LoanApp.NOK_Relationship;
                    original.Organization = LoanApp.Organization;
                    original.Othernames = LoanApp.Othernames;
                    original.PhoneNumber = LoanApp.PhoneNumber;
                    original.RepaymentMethod_FK = LoanApp.RepaymentMethod_FK;
                    original.StateofResidence_FK = LoanApp.StateofResidence_FK;
                    original.Surname = LoanApp.Surname;
                    original.Title_FK = LoanApp.Title_FK;
                    original.IsVisible = 1;
                    original.ValueDate = LoanApp.ValueDate;//MyUtility.getCurrentLocalDateTime().ToString("yyyy/MM/dd"),
                    original.ValueTime = LoanApp.ValueTime; //
                    original.ApplicationStatus_FK = LoanApp.ApplicationStatus_FK;
                    uvDb.SaveChanges();
                }
                return original.ID;

            }
            catch (Exception ex)
            {

                WebLog.Log(ex.Message.ToString());
                return 0;
            }

        }
        public int UpdateLoanApp(string RefNum, DateTime trndate)
        {
            try
            {

                var original = uvDb.LoanApplications.Find(RefNum);
                if (original != null)
                {
                    original.DateModified = trndate;
                    uvDb.SaveChanges();
                }
                return original.ID;

            }


            catch (Exception ex)
            {

                WebLog.Log(ex.Message.ToString());
                return 0;
            }

        }




        public void changePassword(User user)
        {
            try
            {

                // var original = uvDb.Users.Find(user.EmailAddress);
                var original = (from a in uvDb.Users where a.EmailAddress == user.EmailAddress select a).FirstOrDefault();

                if (original != null)
                {



                    original.PaswordVal = user.PaswordVal;
                    original.ReferralLevel = 0;

                    uvDb.SaveChanges();
                }

            }


            catch (Exception ex)
            {

                WebLog.Log(ex.Message.ToString());
            }

        }
        public void UpdatePassword(User user)
        {
            try
            {

                // var original = uvDb.Users.Find(user.EmailAddress);
                var original = (from a in uvDb.Users where a.ID == user.ID select a).FirstOrDefault();

                if (original != null)
                {



                    original.PaswordVal = user.PaswordVal;
                    // original.confirmPassword = user.confirmPassword;


                    uvDb.SaveChanges();
                }

            }


            catch (Exception ex)
            {

                WebLog.Log(ex.Message.ToString());
            }

        }

        public int InsertLoansLedger(LoansLedger Ledger)
        {

            try
            {
                uvDb.LoansLedgers.Add(Ledger);
                uvDb.SaveChanges();

                LoanLedger ldger = new LoanLedger();
                ldger.ApplicantID = Ledger.ApplicantID;
                ldger.Credit = Ledger.Credit;
                ldger.Debit = Ledger.Debit;
                ldger.Institution_FK = Ledger.Institution_FK;
                ldger.InterestAmount = 0;
                ldger.IsVisible = 1;
                ldger.LastUpdated = Ledger.LastUpdated;
                ldger.ManagemntFee = 0;
                ldger.PartnerRefNumber = "Online";
                ldger.PaymentFlag_FK = 0;
                ldger.RefNumber = Ledger.RefNumber;
                ldger.TranxDate = Ledger.trnDate;
                ldger.ValueDate = MyUtility.getCurrentLocalDateTime().ToString("yyyy/MM/dd");
                ldger.ValueTime = MyUtility.getCurrentLocalDateTime().ToString("Hmmss");
                InsertLoanLedger(ldger);
                return Ledger.ID;

            }

            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;

            }

        }
       


        public List<LoanLedger> UpdateLoanLedger(string RefNum, double LoanAmt)
        {
            try
            {


                // var resp = (from a in uvDb.LoanLedgers where a.RefNumber == RefNum select a).ToList();
                var resp = SelectLoanLedger(RefNum, LoanAmt);
                var Firstrecord = resp.First();
                if (Firstrecord != null)
                {
                    Firstrecord.Credit = LoanAmt;
                    Firstrecord.PaymentFlag_FK = 1;
                    uvDb.SaveChanges();
                }

                var query = "UPDATE LoanLedger SET PaymentFlag_FK = 2 WHERE RefNumber = '" + RefNum + "' AND Credit = 0";
                using (var context = new UvlotEntities())
                {
                    context.Database.ExecuteSqlCommand(query);
                }


                if (resp == null)
                {
                    return null;
                }
                return resp.ToList();
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return null;
            }
        }


        public List<LoanLedger> SelectLoanLedger(string RefNum, double LoanAmt)
        {
            try
            {
                var resp = (from a in uvDb.LoanLedgers where a.RefNumber == RefNum select a).ToList();

                if (resp == null)
                {
                    return resp;
                }
                return resp;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return null;
            }
        }


        public int InsertLoansLedger(LoanLedger Ledger)
        {

            try
            {
                uvDb.LoanLedgers.Add(Ledger);
                uvDb.SaveChanges();

                return Ledger.ID;

            }

            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;

            }

        }

        public int insertDocument(DocUpload docUpload)
        {

            try
            {

                uvDb.DocUploads.Add(docUpload);
                uvDb.SaveChanges();

                return docUpload.ID;

            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;

            }

        }

        public int UpdateLoanLedgers(string RefNum)
        {
            try
            {
                var original = (from a in uvDb.LoansLedgers where a.RefNumber == RefNum select a).FirstOrDefault();
                if (original != null)
                {
                    var query = "UPDATE LoansLedger SET IsVisible = 0 WHERE RefNumber = '" + RefNum + "' AND Credit = 0";
                    using (var context = new UvlotEntities())
                    {
                        context.Database.ExecuteSqlCommand(query);
                    }
                    //  original.IsVisible = 0;
                    // uvDb.SaveChanges();
                }
                return original.ID;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;
            }
        }


        public int InsertLoanLedger(LoanLedger Ledger)
        {

            try
            {

                uvDb.LoanLedgers.Add(Ledger);
                uvDb.SaveChanges();

                return Ledger.ID;

            }

            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;

            }

        }

        public int CreateRole(Role roles)
        {

            try
            {
                uvDb.Roles.Add(roles);
                uvDb.SaveChanges();

                return roles.RoleId;

            }

            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;

            }

        }

        public string UpdateRole(Role roles)
        {
            try
            {

                var original = (from a in uvDb.Roles
                                where a.RoleId == roles.RoleId
                                select a).FirstOrDefault();
                if (original != null)
                {
                    original.RoleDescription = roles.RoleDescription;
                    uvDb.SaveChanges();
                }
                return original.RoleId.ToString();

            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return ex.StackTrace.ToString();

            }
        }

        public void InsertUserRoles(UserRole userrole)
        {

            try
            {
                uvDb.UserRoles.Add(userrole);
                uvDb.SaveChanges();


            }

            catch (Exception ex)
            {

                WebLog.Log(ex.Message.ToString());
            }

        }

        public LoanApproval UpdateLoanApproval(LoanApproval LoanApp, LoanApplication LoanApplication)
        {
            try
            {
                var original = (from a in uvDb.LoanApprovals
                                where a.ID == LoanApp.ID
                                select a).FirstOrDefault();

                if (original != null)
                {
                    //original.LoanComment = LoanApp.LoanComment;
                    original.ApplicationStatus_FK = LoanApp.ApplicationStatus_FK;

                    uvDb.SaveChanges();
                }
                return original;

            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return null;
            }
        }




        public int UpdateLoanTenureAndInterestRate(string RefNum, double LoanAmount, int LoanTenure, int INST)
        {
            try
            {
                var InterestRate = (from a in uvDb.LoanInterestRates where a.Institution_FK == INST && a.LoanTenure == LoanTenure select a.InterestRate).FirstOrDefault();
                if (InterestRate == 0)
                {
                    return (int)InterestRate;
                }
                if (InterestRate != 0)
                {
                    var original = (from a in uvDb.LoanApplications
                                    where a.LoanRefNumber == RefNum
                                    select a).FirstOrDefault();

                    if (original != null)
                    {

                        original.ApprovedTenure = LoanTenure;
                        original.ApprovedLoanAmount = LoanAmount;
                        original.ApprovedInterest = InterestRate;

                        uvDb.SaveChanges();
                    }
                    return original.ID;
                }
                return (int)InterestRate;
            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return 0;
            }
        }


        public int UpdateLoanApp(LoanApplication LoanApp)
        {
            try
            {
                var original = (from a in uvDb.LoanApplications
                                where a.LoanRefNumber == LoanApp.LoanRefNumber
                                select a).FirstOrDefault();

                if (original != null)
                {
                    original.LoanComment = LoanApp.LoanComment;
                    original.ApplicationStatus_FK = LoanApp.ApplicationStatus_FK;
                    original.DateModified = LoanApp.DateModified;
                    uvDb.SaveChanges();
                }
                return original.ID;

            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return ex.StackTrace.Count();
            }
        }
        public string UpdateProfile(User users)
        {
            try
            {
                var original = (from a in uvDb.Users
                                where a.ID == users.ID
                                select a).FirstOrDefault();

                if (original != null)
                {
                    original.Firstname = users.Firstname;
                    original.Lastname = users.Lastname;
                    //original.EmailAddress = users.EmailAddress;
                    original.PhoneNumber = users.PhoneNumber;
                    // original.PaswordVal = users.PaswordVal;


                    uvDb.SaveChanges();
                }
                return original.ID.ToString();

            }
            catch (Exception ex)
            {
                WebLog.Log(ex.Message.ToString());
                return ex.StackTrace.ToString();
            }
        }

        public void InsertPageRoles(PageAuthentication pagerole)
        {

            try
            {
                uvDb.PageAuthentications.Add(pagerole);
                uvDb.SaveChanges();


            }

            catch (Exception ex)
            {

                WebLog.Log(ex.Message.ToString());
            }

        }



    }


}

public class Remitaresp
{
    public string respCode { get; set; }

    public string respDescription { get; set; }

    public float Amount { get; set; }

    public string requestID { get; set; }

    public string mandateID { get; set; }

    public string transactionRef { get; set; }

    public string RRR { get; set; }

    public string refNumber { get; set; }

    public string fundingBankCode { get; set; }

    public string fundingAccount { get; set; }

    public DateTime TransactDate { get; set; }
    public string RespExtra { get; set; }

    public string RespExtra1 { get; set; }

    public string RespExtra2 { get; set; }

    public string Response { get; set; }

}
