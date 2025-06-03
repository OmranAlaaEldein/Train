using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoreTrain.Dto;
using DomainTrain.model;


namespace Core_engtraining.IAppServices
{
  
  public interface ISuggestionsService
    {
        public List<Suggestions> GetAllSuggestions(int pageSize = 10, int pageNumber = 1, string orderBy = "title", string orderType = "asc");
        public Suggestions GetSuggestionsById(Guid id);
        public bool IsExistById(Guid id);
        public bool AddSuggestions(Suggestions_Dto newSuggestions);
        public bool UpdateSuggestions(Guid id, Suggestions_Dto updatedSuggestions);
        public bool DeleteSuggestions(Guid id);
    }
}
