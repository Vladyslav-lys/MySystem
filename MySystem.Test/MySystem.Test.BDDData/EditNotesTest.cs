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
//Feature: TestEditNotes
//    In order to edit notes

//    As a user
//    I want to edit notes info

//Scenario: Edit according notes successful

//    Given User try to connect the server

//    When it will be successful
//    When User try to enter by login: z and password: pas through Client
//    When it will be successful

//    When User try to get account by IdUser: 10
//	When it will be successful
//    When User try to get notes by IdAccount: 2
//	When it will be successful
//    When User try to edit notes by Id: 2 and Topic: tref and Text: df and DateTime: new DateTime(2019,11,11) and Image: new byte[0] and IdAccount: 2
//	Then it will be successful
