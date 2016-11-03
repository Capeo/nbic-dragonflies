using System.Collections.Generic;

namespace NbicDragonflies.Models.Taxon
{

    public class Tag
    {
        public string Heading { get; set; }
        public List<object> Literals { get; set; }
        public object Body { get; set; }
        public List<object> Tags { get; set; }
        public List<object> Templates { get; set; }
        public string Url { get; set; }
        public List<object> References { get; set; }
        public List<object> Files { get; set; }
        public List<object> Records { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<string> Languages { get; set; }
        public object Created { get; set; }
        public object Published { get; set; }
        public string Changed { get; set; }
    }

    public class Reference
    {
        public List<object> Literals { get; set; }
        public List<object> Metadata { get; set; }
        public object License { get; set; }
        public object Body { get; set; }
        public List<Tag> Tags { get; set; }
        public List<object> Templates { get; set; }
        public string Url { get; set; }
        public List<object> References { get; set; }
        public List<object> Files { get; set; }
        public List<object> Records { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<object> Languages { get; set; }
        public string Created { get; set; }
        public object Published { get; set; }
        public string Changed { get; set; }
    }

    public class Metadata
    {
        public object Label { get; set; }
        public List<object> Values { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Reference> References { get; set; }
        public object Cite { get; set; }
    }

    public class Literal
    {
        public object Label { get; set; }
        public List<string> Values { get; set; }
        public List<Tag> Tags { get; set; }
    }

    public class License
    {
        public string Heading { get; set; }
        public List<Literal> Literals { get; set; }
        public object Body { get; set; }
        public List<object> Tags { get; set; }
        public List<object> Templates { get; set; }
        public string Url { get; set; }
        public List<object> References { get; set; }
        public List<object> Files { get; set; }
        public List<object> Records { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<string> Languages { get; set; }
        public object Created { get; set; }
        public object Published { get; set; }
        public string Changed { get; set; }
    }


    public class TaxonInfo
    {
        public string Heading { get; set; }
        public string Intro { get; set; }
        public List<Metadata> Metadata { get; set; }
        public License License { get; set; }
        public List<object> Content { get; set; }
        public object Body { get; set; }
        public List<Tag> Tags { get; set; }
        public List<object> Templates { get; set; }
        public string Url { get; set; }
        public List<Reference> References { get; set; }
        public List<object> Files { get; set; }
        public List<object> Records { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<string> Languages { get; set; }
        public object Created { get; set; }
        public object Published { get; set; }
        public string Changed { get; set; }
    }

}
