using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.DomainEvents;
using MySystem.BL.Contract;
using MySystem.DAL.Entities;

namespace MySystem.BL.UseCases
{
    public class GetNotesUseCase : IUseCase<GetNotesResponse, GetNotesRequest>
    {
        private IGetNotesActivity getNotesActivity;

        public GetNotesUseCase(IGetNotesActivity getNotesActivity)
        {
            this.getNotesActivity = getNotesActivity;
        }

        public GetNotesResponse Execute(GetNotesRequest request)
        {
            try
            {
                List<Notes> notes = getNotesActivity.Run(request.IdAccount);
                return new GetNotesResponse(notes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
