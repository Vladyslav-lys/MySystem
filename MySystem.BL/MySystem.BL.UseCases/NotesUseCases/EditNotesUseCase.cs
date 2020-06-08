using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.DomainEvents;
using MySystem.BL.Contract;
using MySystem.DAL.Entities;

namespace MySystem.BL.UseCases
{
    public class EditNotesUseCase : IUseCase<EditNotesResponse, EditNotesRequest>
    {
        private IValidationActivity<EditNotesRequest> editNotesValidationActivity;
        private IEditNotesActivity editNotesActivity;
        private IGetNotesActivity getNotesActivity;

        public EditNotesUseCase(IValidationActivity<EditNotesRequest> editNotesValidationActivity, IEditNotesActivity editNotesActivity, IGetNotesActivity getNotesActivity)
        {
            this.editNotesValidationActivity = editNotesValidationActivity;
            this.editNotesActivity = editNotesActivity;
            this.getNotesActivity = getNotesActivity;
        }

        public EditNotesResponse Execute(EditNotesRequest request)
        {
            try
            {
                editNotesValidationActivity.Validate(request);
                editNotesActivity.Run(request.Id, request.Topic, request.Text, request.Date, request.Image, request.IdAccount);
                List<Notes> notes = getNotesActivity.Run(request.IdAccount);
                return new EditNotesResponse(notes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
