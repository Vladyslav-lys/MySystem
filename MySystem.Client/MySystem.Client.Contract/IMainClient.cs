using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySystem.Service.Domain;

namespace MySystem.Client.Contract
{
    public interface IMainClient
    {
        Task ConnectAsync(); //Ассинхронное соединение по заданному адреса
        Task DisconnectAsync(); //Остановить соединение
        Task<UserDTO> EnterAsync(string login, string password); //Ассинхронный вход пользователя
        bool IsConnected { get; set; }
        Task<AccountDTO> ShowAccountAsync(int idUser);
        Task<OperationStatusInfo> UpdateAccountAsync(AccountDTO accountDTO);
        Task<List<NotesDTO>> ShowNotesAsync(int idAccount);
        Task<OperationStatusInfo> UpdateNotesAsync(NotesDTO notesDTO);
        Task<OperationStatusInfo> AddNotesAsync(NotesDTO notesDTO);
    }
}
