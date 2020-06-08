using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.DomainEvents;
using MySystem.BL.Contract;
using MySystem.DAL.Entities;

namespace MySystem.BL.UseCases
{
    public class AddNotesUseCase : IUseCase<AddNotesResponse, AddNotesRequest>
    {
        private IValidationActivity<AddNotesRequest> addNotesValidationActivity;
        private IAddNotesActivity addNotesActivity;
        private IGetNotesActivity getNotesActivity;

        public AddNotesUseCase(IValidationActivity<AddNotesRequest> addNotesValidationActivity, IAddNotesActivity addNotesActivity, IGetNotesActivity getNotesActivity)
        {
            this.addNotesValidationActivity = addNotesValidationActivity;
            this.addNotesActivity = addNotesActivity;
            this.getNotesActivity = getNotesActivity;
        }

        public AddNotesResponse Execute(AddNotesRequest request)
        {
            try
            {
                addNotesValidationActivity.Validate(request);
                addNotesActivity.Run(request.Topic, request.Text, request.Date, request.Image, request.IdAccount);
                List<Notes> notes = getNotesActivity.Run(request.IdAccount);
                return new AddNotesResponse(notes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
