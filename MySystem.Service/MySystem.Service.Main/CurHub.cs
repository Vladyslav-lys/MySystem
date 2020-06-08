using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MySystem.Service.Domain;
using MySystem.BL.UseCases;
using MySystem.BL.Contract;
using MySystem.BL.DomainEvents;
using MySystem.DAL.Entities;
using Newtonsoft.Json;

namespace MySystem.Service.Main
{
    public class CurHub : Hub
    {
        private HubController hubController;

        public CurHub(HubController hubController)
        {
            this.hubController = hubController;
        }

        public async Task Send(string message)
        {
            Console.WriteLine(message);
            await this.Clients.All.SendAsync("Notify", message);
        }

        public async Task<OperationStatusInfo> Enter(string login, string password)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetUserRequest getUserRequest = new GetUserRequest(login, password);

                try
                {
                    GetUserResponse getUserResponse = hubController.UseCaseFactory.CreateLoginUseCase().Execute(getUserRequest);
                    UserDTO userDTO = hubController.TransformUser(getUserResponse.User);
                    operationStatusInfo.AttachedObject = userDTO;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> ShowAccount(int idUser)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetAccountRequest getAccountRequest = new GetAccountRequest(idUser);

                try
                {
                    GetAccountResponse getAccountResponse = hubController.UseCaseFactory.CreateGetAccountUseCase().Execute(getAccountRequest);
                    AccountDTO accountDTO = hubController.TransformAccount(getAccountResponse.Account);
                    operationStatusInfo.AttachedObject = accountDTO;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> UpdateAccount(object updatedAccount)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

                string attachedObjectText = updatedAccount.ToString();
                Account newAccount = JsonConvert.DeserializeObject<Account>(attachedObjectText);
                EditAccountRequest editAccountRequest = new EditAccountRequest(newAccount.Id, newAccount.LastName, newAccount.FirstName, newAccount.SecondName, newAccount.Photo);

                try
                {
                    EditAccountResponse editAccountResponse = hubController.UseCaseFactory.CreateEditAccountUseCase().Execute(editAccountRequest);
                    AccountDTO accountDTO = hubController.TransformAccount(editAccountResponse.Account);
                    operationStatusInfo.AttachedObject = accountDTO;
                    operationStatusInfo.AttachedInfo = "Account is updated!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> ShowNotes(int idAccount)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetNotesRequest getNotesRequest = new GetNotesRequest(idAccount);

                try
                {
                    GetNotesResponse getNotesResponse = hubController.UseCaseFactory.CreateGetNotesUseCase().Execute(getNotesRequest);
                    List<NotesDTO> notesDTO = hubController.TransformNotes(getNotesResponse.Notes);
                    operationStatusInfo.AttachedObject = notesDTO;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> UpdateNotes(object updatedNotes)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

                string attachedObjectText = updatedNotes.ToString();
                Notes newNotes = JsonConvert.DeserializeObject<Notes>(attachedObjectText);
                EditNotesRequest editNotesRequest = new EditNotesRequest(newNotes.Id, newNotes.Topic, newNotes.Text, newNotes.Date, newNotes.Image, newNotes.IdAccount);

                try
                {
                    EditNotesResponse editNotesResponse = hubController.UseCaseFactory.CreateEditNotesUseCase().Execute(editNotesRequest);
                    List<NotesDTO> notesDTO = hubController.TransformNotes(editNotesResponse.Notes);
                    operationStatusInfo.AttachedObject = notesDTO;
                    operationStatusInfo.AttachedInfo = "Notes are updated!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> AddNotes(object addedNotes)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

                string attachedObjectText = addedNotes.ToString();
                Notes newNotes = JsonConvert.DeserializeObject<Notes>(attachedObjectText);
                AddNotesRequest addNotesRequest = new AddNotesRequest(newNotes.Topic, newNotes.Text, newNotes.Date, newNotes.Image, newNotes.IdAccount);

                try
                {
                    AddNotesResponse addNotesResponse = hubController.UseCaseFactory.CreateAddNotesUseCase().Execute(addNotesRequest);
                    List<NotesDTO> notesDTO = hubController.TransformNotes(addNotesResponse.Notes);
                    operationStatusInfo.AttachedObject = notesDTO;
                    operationStatusInfo.AttachedInfo = "Notes are added!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }
    }
}
//private static List<string> connectionList = new List<string>();

//public async Task Exit()
//{
//    string connectionId = this.Context.ConnectionId;

//    try
//    {
//        await Task.Run(() =>
//        {

//            if (this.IsContainConnection)
//            {
//                this.RemoveConnection(connectionId);
//            }
//            else
//            {
//                throw new Exception("The user is not entered! Cannot quit the system.");
//            }
//        });
//    }
//    catch (Exception ex)
//    {
//        string errorMsg = "The user is not entered! Cannot quit the system.";
//        Console.WriteLine(errorMsg);
//    }
//}

//private bool IsContainConnection
//{
//    get { return connectionList.Contains(this.Context.ConnectionId); }
//}

//private Task AddConnection(string connectionId)
//{
//    return Task.Run(() =>
//    {
//        if (!connectionList.Contains(connectionId))
//        {
//            connectionList.Add(connectionId);
//        }
//    });
//}

//private Task RemoveConnection(string connectionId)
//{
//    return Task.Run(() =>
//    {
//        if (connectionList.Contains(connectionId))
//        {
//            connectionList.Remove(connectionId);
//        }
//    });
//}

