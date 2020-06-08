using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MySystem.BL.Contract;
using MySystem.BL.Activities;
using MySystem.BL.UseCases;
using MySystem.DAL.Entities;
using MySystem.DAL.Contract;
using MySystem.DAL.Repositories;
using MySystem.Service.Domain;
using MySystem.Service.Contract;
using System.Collections.Generic;

namespace MySystem.Service.Main
{
    public class HubController
    {
        private IHubContext<CurHub> hubContext;
        private IUseCaseFactory useCaseFactory;

        public HubController(IHubContext<CurHub> hubContext, IValidationRuleFactory validationRuleFactory)
        {
            IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
            IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            IActivityFactory activityFactory = new ActivityFactory(unitOfWork, validationRuleFactory);

            this.useCaseFactory = new UseCaseFactory(activityFactory);
            this.hubContext = hubContext;
        }

        public IUseCaseFactory UseCaseFactory
        {
            get { return this.useCaseFactory; }
            set { this.useCaseFactory = value; }
        }
        
        public UserDTO TransformUser(User user)
        {
            return new UserDTO(user.Id, user.Login, user.Password);
        }
        
        public AccountDTO TransformAccount(Account account)
        {
            return new AccountDTO(account.Id, account.LastName, account.FirstName, account.SecondName, account.Photo, account.IdUser);
        }

        public Account TransformAccountDTO(AccountDTO accountDTO)
        {
            return new Account()
            {
                Id = accountDTO.Id,
                LastName = accountDTO.LastName,
                FirstName = accountDTO.FirstName,
                SecondName = accountDTO.SecondName,
                IdUser = accountDTO.IdUser
            };
        }

        public List<NotesDTO> TransformNotes(List<Notes> notes)
        {
            List<NotesDTO> notesDTO = new List<NotesDTO>();

            for (int i = 0; i < notes.Count; i++)
            {
                notesDTO.Add(new NotesDTO(notes[i].Id, notes[i].Topic, notes[i].Text, notes[i].Date, notes[i].Image, notes[i].IdAccount));
            }

            return notesDTO;
        }

        public Notes TransformNotesDTO(NotesDTO notesDTO)
        {
            return new Notes()
            {
                Id = notesDTO.Id,
                Topic = notesDTO.Topic,
                Text = notesDTO.Text,
                Date = notesDTO.Date,
                Image = notesDTO.Image,
                IdAccount = notesDTO.IdAccount
            };
        }
    }
}

//public UserDTO GetUserDTOAsync(string login, string password)
//{
//    User user = this.useCaseFactory.CreateLoginUseCase();

//    return this.TransformUser(user);
//}

//public AccountDTO GetAccountDTOAsync(int idUser)
//{
//    Account account = await this.accountProduct.GetAccountAsync(idUser);

//    return this.TransformAccount(account);
//}

//public bool UpdateAccountAsync(AccountDTO accountDTO)
//{
//    Account account = this.TransformAccountDTO(accountDTO);
//    bool isUpdated = await this.accountProduct.UpdateAccountAsync(account);

//    return isUpdated;
//}