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
//Feature: TestGetNotes
//    In order to get notes

//    As a user
//    I want to get notes info

//Scenario: Get according notes successful

//    Given User try to connect the server

//    When it will be successful
//    When User try to enter by login: z and password: pas through Client
//    When it will be successful

//    When User try to get account by IdUser: 10
//	When it will be successful
//    When User try to get notes by IdAccount: 2
//	Then it will be successful
