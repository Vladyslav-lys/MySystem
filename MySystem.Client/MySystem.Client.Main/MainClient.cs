using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using MySystem.Service.Domain;
using MySystem.Client.Contract;
using Newtonsoft.Json;
using System.Configuration;

namespace MySystem.Client.Main
{
    public class MainClient : IMainClient
    {
        private SystemSettings systemSettings;
        private bool isConnected;

        public MainClient()
        {
            string serviceurl = ConfigurationManager.AppSettings["ServiceUrl"];
            string hubname = ConfigurationManager.AppSettings["Hub"];
            this.isConnected = false;

            this.systemSettings = new SystemSettings(hubname, serviceurl, null);
        }

        public SystemSettings SystemSettings
        {
            get { return this.systemSettings; }
            set { this.systemSettings = value; }
        }

        public bool IsConnected
        {
            get { return this.isConnected; }
            set { this.isConnected = value; }
        }

        //Ассинхронное соединение по заданному адреса
        public async Task ConnectAsync()
        {
            try
            {
                this.systemSettings.Connection = new HubConnectionBuilder().WithUrl(this.systemSettings.FullPath).Build();

                await this.systemSettings.Connection.StartAsync();
                await this.systemSettings.Connection.InvokeAsync("send", "Connected!");
            }
            catch (Exception ex)
            {
                throw new Exception("Connection is not executed. Reason: There is no requested server", ex);
            }
        }

        //Остановить соединение
        public async Task DisconnectAsync()
        {
            try
            {
                await this.systemSettings.Connection.StopAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Disconnection is not executed. Reason: There is no connection with the server", ex);
            }
        }

        //Ассинхронный вход пользователя
        public async Task<UserDTO> EnterAsync(string login, string password)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("enter", login, password);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    UserDTO userDTO = JsonConvert.DeserializeObject<UserDTO>(attachedObjectText);

                    return userDTO;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                this.isConnected = false;
                throw new Exception("Enter is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Enter is not executed. Reason: " + ex.Message, ex);
            }
        }

        public async Task<AccountDTO> ShowAccountAsync(int idUser)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("ShowAccount", idUser);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    AccountDTO accountDTO = JsonConvert.DeserializeObject<AccountDTO>(attachedObjectText);

                    return accountDTO;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                this.isConnected = false;
                throw new Exception("Showing is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Showing is not executed. Reason: " + ex.Message, ex);
            }
        }
        
        public async Task<OperationStatusInfo> UpdateAccountAsync(AccountDTO accountDTO)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("UpdateAccount", accountDTO);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    return operationStatusInfo;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Updating is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Updating is not executed. Reason:" + ex.Message, ex);
            }
        }

        public async Task<List<NotesDTO>> ShowNotesAsync(int idAccount)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("ShowNotes", idAccount);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<NotesDTO> notesDTO = JsonConvert.DeserializeObject<List<NotesDTO>>(attachedObjectText);

                    return notesDTO;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                this.isConnected = false;
                throw new Exception("Showing is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Showing is not executed. Reason: " + ex.Message, ex);
            }
        }

        public async Task<OperationStatusInfo> UpdateNotesAsync(NotesDTO notesDTO)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("UpdateNotes", notesDTO);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    return operationStatusInfo;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Updating is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Updating is not executed. Reason:" + ex.Message, ex);
            }
        }

        public async Task<OperationStatusInfo> AddNotesAsync(NotesDTO notesDTO)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("AddNotes", notesDTO);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    return operationStatusInfo;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Adding is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Adding is not executed. Reason:" + ex.Message, ex);
            }
        }
    }
}
