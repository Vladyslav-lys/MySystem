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
    public class EditNotesTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
        OperationStatusInfo operationStatusInfo = null;

        [When("User try to edit notes by (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public async Task EditNotes(int id, string topic, string text, DateTime dateTime, byte[] image, int idAccount)
        {
            try
            {
                NotesDTO notesDTO = new NotesDTO(id, topic, text, dateTime, image, idAccount);
                operationStatusInfo = await this.mainClient.UpdateNotesAsync(notesDTO);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}

