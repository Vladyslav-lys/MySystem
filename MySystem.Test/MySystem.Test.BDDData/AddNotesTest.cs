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
//Feature: TestAddNotes
//    In order to add notes

//    As a user
//    I want to add notes info

//Scenario: Add according notes successful

//    Given User try to connect the server

//    When it will be successful
//    When User try to enter by login: z and password: pas through Client
//    When it will be successful

//    When User try to get account by IdUser: 10
//	When it will be successful
//    When User try to get notes by IdAccount: 2
//	When it will be successful
//    When User try to add notes by Topic: tref and Text: df and DateTime: new DateTime(2019,11,11) and Image: new byte[0] and IdAccount: 2
//	Then it will be successful
