
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
using System.Xml.Serialization;

/// <remarks/>
/// 
var client = new HttpClient();
var xmlResult = await client.GetStringAsync("http://api.napiarfolyam.hu?bank=mnb&valuta=eur&datum=20240311&datumend=20240411");

var serializer = new XmlSerializer(typeof(arfolyamok));
arfolyamok result;
using TextReader reader = new StringReader(xmlResult);
result = (arfolyamok)serializer.Deserialize(reader);
var strongestKozep = new decimal();
var strongesDate = "";
foreach(var i in result.deviza)
{
    if(i.kozep > strongestKozep) 
    {
        strongestKozep = i.kozep;
        strongesDate = i.datum;
    }
    Console.WriteLine($"Pénznem: {i.penznem}; Bank: {i.bank}; Közép: {i.kozep}; Dátum: {i.datum}");
}
Console.WriteLine($"\n{strongesDate} kor volt a legerősebb a HUF az EUR-hoz képes: {strongestKozep}");

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class arfolyamok
{

    private arfolyamokItem[] valutaField;

    private arfolyamokItem1[] devizaField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
    public arfolyamokItem[] valuta
    {
        get
        {
            return this.valutaField;
        }
        set
        {
            this.valutaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
    public arfolyamokItem1[] deviza
    {
        get
        {
            return this.devizaField;
        }
        set
        {
            this.devizaField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class arfolyamokItem
{

    private string bankField;

    private string datumField;

    private string penznemField;

    private decimal vetelField;

    private decimal eladasField;

    /// <remarks/>
    public string bank
    {
        get
        {
            return this.bankField;
        }
        set
        {
            this.bankField = value;
        }
    }

    /// <remarks/>
    public string datum
    {
        get
        {
            return this.datumField;
        }
        set
        {
            this.datumField = value;
        }
    }

    /// <remarks/>
    public string penznem
    {
        get
        {
            return this.penznemField;
        }
        set
        {
            this.penznemField = value;
        }
    }

    /// <remarks/>
    public decimal vetel
    {
        get
        {
            return this.vetelField;
        }
        set
        {
            this.vetelField = value;
        }
    }

    /// <remarks/>
    public decimal eladas
    {
        get
        {
            return this.eladasField;
        }
        set
        {
            this.eladasField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class arfolyamokItem1
{

    private string bankField;

    private string datumField;

    private string penznemField;

    private decimal kozepField;

    private bool kozepFieldSpecified;

    private decimal vetelField;

    private bool vetelFieldSpecified;

    private decimal eladasField;

    private bool eladasFieldSpecified;

    /// <remarks/>
    public string bank
    {
        get
        {
            return this.bankField;
        }
        set
        {
            this.bankField = value;
        }
    }

    /// <remarks/>
    public string datum
    {
        get
        {
            return this.datumField;
        }
        set
        {
            this.datumField = value;
        }
    }

    /// <remarks/>
    public string penznem
    {
        get
        {
            return this.penznemField;
        }
        set
        {
            this.penznemField = value;
        }
    }

    /// <remarks/>
    public decimal kozep
    {
        get
        {
            return this.kozepField;
        }
        set
        {
            this.kozepField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool kozepSpecified
    {
        get
        {
            return this.kozepFieldSpecified;
        }
        set
        {
            this.kozepFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal vetel
    {
        get
        {
            return this.vetelField;
        }
        set
        {
            this.vetelField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool vetelSpecified
    {
        get
        {
            return this.vetelFieldSpecified;
        }
        set
        {
            this.vetelFieldSpecified = value;
        }
    }

    /// <remarks/>
    public decimal eladas
    {
        get
        {
            return this.eladasField;
        }
        set
        {
            this.eladasField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool eladasSpecified
    {
        get
        {
            return this.eladasFieldSpecified;
        }
        set
        {
            this.eladasFieldSpecified = value;
        }
    }
}
