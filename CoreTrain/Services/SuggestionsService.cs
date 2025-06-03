using System;
using System.Collections.Generic;
using System.Text;
using Core_engtraining.IAppServices;
using DomainTrain.model;

namespace Core_engtraining.Services
{
    public class SuggestionsService : ISuggestionsService
    {
        public bool AddSuggestions(Suggestions_Dto newSuggestions)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSuggestions(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Suggestions> GetAllSuggestions(int pageSize = 10, int pageNumber = 1, string orderBy = "title", string orderType = "asc")
        {
            throw new NotImplementedException();
        }

        public string GetSuggestion(int id)
        {
            return "";
        }

        public Suggestions GetSuggestionsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsExistById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSuggestions(Guid id, Suggestions_Dto updatedSuggestions)
        {
            throw new NotImplementedException();
        }
    }
}
