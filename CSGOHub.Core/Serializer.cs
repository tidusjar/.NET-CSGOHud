using CSGOHub.Core.Json;

using Newtonsoft.Json;

namespace CSGOHub.Core
{
   public  class Serializer
    {
       public CsgoPayload DeserializeFake()
       {
            var jsonData = JsonResource.PayloadExample;
            return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<CsgoPayload>(jsonData) : new CsgoPayload();
        }
        public CsgoPayload Deserialize(string jsonData)
        {
            return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<CsgoPayload>(jsonData) : new CsgoPayload();
        }
    }
}
