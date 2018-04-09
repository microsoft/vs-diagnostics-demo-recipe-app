using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Recipe.Service.Models
{
    public partial class Recipe
    {
        [JsonProperty("vegetarian", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Vegetarian { get; set; }

        [JsonProperty("vegan", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Vegan { get; set; }

        [JsonProperty("glutenFree", NullValueHandling = NullValueHandling.Ignore)]
        public bool? GlutenFree { get; set; }

        [JsonProperty("dairyFree", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DairyFree { get; set; }

        [JsonProperty("veryHealthy", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VeryHealthy { get; set; }

        [JsonProperty("cheap", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Cheap { get; set; }

        [JsonProperty("veryPopular", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VeryPopular { get; set; }

        [JsonProperty("sustainable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Sustainable { get; set; }

        [JsonProperty("weightWatcherSmartPoints", NullValueHandling = NullValueHandling.Ignore)]
        public long? WeightWatcherSmartPoints { get; set; }

        [JsonProperty("gaps", NullValueHandling = NullValueHandling.Ignore)]
        public string Gaps { get; set; }

        [JsonProperty("lowFodmap", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LowFodmap { get; set; }

        [JsonProperty("ketogenic", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Ketogenic { get; set; }

        [JsonProperty("whole30", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Whole30 { get; set; }

        [JsonProperty("servings", NullValueHandling = NullValueHandling.Ignore)]
        public long? Servings { get; set; }

        [JsonProperty("sourceUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceUrl { get; set; }

        [JsonProperty("spoonacularSourceUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string SpoonacularSourceUrl { get; set; }

        [JsonProperty("aggregateLikes", NullValueHandling = NullValueHandling.Ignore)]
        public long? AggregateLikes { get; set; }

        [JsonProperty("spoonacularScore", NullValueHandling = NullValueHandling.Ignore)]
        public long? SpoonacularScore { get; set; }

        [JsonProperty("healthScore", NullValueHandling = NullValueHandling.Ignore)]
        public long? HealthScore { get; set; }

        [JsonProperty("creditText", NullValueHandling = NullValueHandling.Ignore)]
        public string CreditText { get; set; }

        [JsonProperty("license", NullValueHandling = NullValueHandling.Ignore)]
        public string License { get; set; }

        [JsonProperty("sourceName", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceName { get; set; }

        [JsonProperty("pricePerServing", NullValueHandling = NullValueHandling.Ignore)]
        public double? PricePerServing { get; set; }

        [JsonProperty("extendedIngredients", NullValueHandling = NullValueHandling.Ignore)]
        public List<ExtendedIngredient> ExtendedIngredients { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("readyInMinutes", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReadyInMinutes { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("imageType", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageType { get; set; }

        [JsonProperty("cuisines", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Cuisines { get; set; }

        [JsonProperty("dishTypes", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DishTypes { get; set; }

        [JsonProperty("diets", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Diets { get; set; }

        [JsonProperty("occasions", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Occasions { get; set; }

        [JsonProperty("winePairing", NullValueHandling = NullValueHandling.Ignore)]
        public WinePairing WinePairing { get; set; }

        [JsonProperty("instructions", NullValueHandling = NullValueHandling.Ignore)]
        public string Instructions { get; set; }

        [JsonProperty("analyzedInstructions", NullValueHandling = NullValueHandling.Ignore)]
        public List<AnalyzedInstruction> AnalyzedInstructions { get; set; }

        [JsonProperty("creditsText", NullValueHandling = NullValueHandling.Ignore)]
        public string CreditsText { get; set; }
    }

    public partial class AnalyzedInstruction
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("steps", NullValueHandling = NullValueHandling.Ignore)]
        public List<Step> Steps { get; set; }
    }

    public partial class Step
    {
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public long? Number { get; set; }

        [JsonProperty("step", NullValueHandling = NullValueHandling.Ignore)]
        public string StepStep { get; set; }

        [JsonProperty("ingredients", NullValueHandling = NullValueHandling.Ignore)]
        public List<Ent> Ingredients { get; set; }

        [JsonProperty("equipment", NullValueHandling = NullValueHandling.Ignore)]
        public List<Ent> Equipment { get; set; }
    }

    public partial class Ent
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }
    }

    public partial class ExtendedIngredient
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("aisle", NullValueHandling = NullValueHandling.Ignore)]
        public string Aisle { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("consistency", NullValueHandling = NullValueHandling.Ignore)]
        public string Consistency { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? Amount { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("originalString", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalString { get; set; }

        [JsonProperty("metaInformation", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MetaInformation { get; set; }
    }

    public partial class WinePairing
    {
        [JsonProperty("pairedWines", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> PairedWines { get; set; }

        [JsonProperty("pairingText", NullValueHandling = NullValueHandling.Ignore)]
        public string PairingText { get; set; }

        [JsonProperty("productMatches", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> ProductMatches { get; set; }
    }

    public partial class Recipe
    {
        public static Recipe FromJson(string json) => JsonConvert.DeserializeObject<Recipe>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Recipe self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
