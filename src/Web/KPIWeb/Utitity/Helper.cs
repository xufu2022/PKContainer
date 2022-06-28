using Microsoft.AspNetCore.Mvc.Rendering;

namespace KPIWeb.Utitity
{
    public  class Helper
    {
        public List<SelectListItem> PopulateDirectionList(IEnumerable<DirectionsOfTravelDto> entries, bool withPrompt)
        {
            var result = new List<SelectListItem>();
            if (withPrompt)
                result.Add(new SelectListItem
                {
                    Text = "Please Select...",
                    Value = "0"
                });

            result.AddRange(entries.OrderBy(x => x.Name).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));

            return result;
        }
    }
}
