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
    public class AddNotesTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
        OperationStatusInfo operationStatusInfo = null;

        [When("User try to add notes by (.*) and (.*) and (.*) and (.*) and (.*)")]
        public async Task EditNotes(string topic, string text, DateTime dateTime, byte[] image, int idAccount)
        {
            try
            {
                NotesDTO notesDTO = new NotesDTO();
                notesDTO.Topic = topic;
                notesDTO.Text = text;
                notesDTO.Date = dateTime;
                notesDTO.Image = image;
                notesDTO.IdAccount = idAccount;
                operationStatusInfo = await this.mainClient.AddNotesAsync(notesDTO);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}

