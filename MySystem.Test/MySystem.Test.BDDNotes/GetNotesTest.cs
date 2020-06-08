using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Configuration;
using MySystem.Service.Domain;
using MySystem.Test.BDDLogin;

namespace MySystem.Test.BDDData
{
    [Binding]
    public class GetNotesTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
        List<NotesDTO> notesDTO = new List<NotesDTO>();

        [When("User try to get notes by (.*)")]
        public async Task GetNotes(int idAccount)
        {
            try
            {
                notesDTO = await this.mainClient.ShowNotesAsync(idAccount);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}

