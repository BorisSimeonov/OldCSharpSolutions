using System;

class Laptop
{
    // --- Mandatory

    private string modelField;

    private decimal priceField;

    // --- Optional

    private string manifacturerField = null;

    private string processorField = null;

    private string ramField = null;

    private string videoCardField = null;

    private string HDDField = null;

    private string displayField = null;

    //Battery Class Fields

    private Battery batteryObject = new Battery();


    //---------------- CONSTRUCTORS ---------------------------------------------

    public Laptop(string model, decimal price)
    {
        this.Model = model;
        this.Price = price;
    }

    public Laptop(string model, decimal price, string manifacturer)
    {
        this.Model = model;
        this.Price = price;
        this.Manifacturer = manifacturer;
    }

    public Laptop(string model, decimal price, string manifacturer, string processor)
    {
        this.Model = model;
        this.Price = price;
        this.Manifacturer = manifacturer;
        this.Processor = processor;
    }

    public Laptop(string model, decimal price, string manifacturer, string processor,
        string ram)
    {
        this.Model = model;
        this.Price = price;
        this.Manifacturer = manifacturer;
        this.Processor = processor;
        this.RAM = ram;
    }

    public Laptop(string model, decimal price, string manifacturer, string processor,
        string ram, string videoCard)
    {
        this.Model = model;
        this.Price = price;
        this.Manifacturer = manifacturer;
        this.Processor = processor;
        this.RAM = ram;
        this.VideoCard = videoCard;
    }

    public Laptop(string model, decimal price, string manifacturer, string processor,
        string ram, string videoCard, string hardDisk)
    {
        this.Model = model;
        this.Price = price;
        this.Manifacturer = manifacturer;
        this.Processor = processor;
        this.RAM = ram;
        this.VideoCard = videoCard;
        this.HardDisk = hardDisk;
    }

    public Laptop(string model, decimal price, string manifacturer, string processor,
        string ram, string videoCard, string hardDisk, string display)
    {
        this.Model = model;
        this.Price = price;
        this.Manifacturer = manifacturer;
        this.Processor = processor;
        this.RAM = ram;
        this.VideoCard = videoCard;
        this.HardDisk = hardDisk;
        this.Display = display;
    }

    public Laptop(string model, decimal price, string manifacturer, string processor,
        string ram, string videoCard, string hardDisk, string display,
        string batteryName, double batteryUsageDuration)
    {
        this.Model = model;
        this.Price = price;
        this.Manifacturer = manifacturer;
        this.Processor = processor;
        this.RAM = ram;
        this.VideoCard = videoCard;
        this.HardDisk = hardDisk;
        this.Display = display;
        this.BatteryName = batteryName;
        this.BatteryDurationValue = batteryUsageDuration;
    }

    //---------------- PROPERTIES ---------------------------------------------

    public string Model
    {
        get
        {
            return this.modelField;
        }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Length > 2 && value.Length < 25)
                {
                    modelField = value;
                    isValid = true;
                }
            }

            if (!isValid)
            {
                throw new FormatException("Model: Invalid Model Name format.");
            }
        }
    }

    public decimal Price
    {
        get
        {
            return this.priceField;
        }
        set
        {
            if (value > 0m)
            {
                priceField = value;
            }
            else
            {
                throw new IndexOutOfRangeException(
                    "Price: only positive and higher than 0 numbers are allowed.");
            }
        }
    }

    public string Manifacturer
    {
        get
        {
            return this.manifacturerField;
        }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Length >= 2 && value.Length < 30)
                {
                    manifacturerField = value;
                    isValid = true;
                }
            }

            if (!isValid)
            {
                throw new FormatException(value == null ?
                    "Manifacturer: Invalid Model Name format. Null value." :
                    "Manifacturer: Invalid Model Name format. Too short name.");
            }
        }
    }

    public string Processor
    {
        get
        {
            return this.processorField;
        }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Length >= 3 && value.Length < 100)
                {
                    processorField = value;
                    isValid = true;
                }
            }

            if (!isValid)
            {
                throw new FormatException(value == null ?
                    "Processor: Invalid Processor Model Name format. Null value." :
                    "Processor: Invalid Processor Model Name format. Invalid Text Length.");
            }
        }
    }

    public string RAM
    {
        get
        {
            return this.ramField;
        }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Length >= 3 && value.Length < 25 &&
                    System.Text.RegularExpressions.Regex.IsMatch(value,
                    @"^([1-9][0-9]*\s*[gbGBmM]{2}(\s*[drDR]+[1-3])*\s*([1-9][0-9]+[mhzMHZ]+)*)$"))
                {
                    ramField = value.Trim();
                    isValid = true;
                }
            }

            if (!isValid)
            {
                throw new FormatException(value == null ?
                    "RAM: Invalid Model Name format. Null value." :
                    "RAM: Invalid RAM format. (ex.: 8 GB | 512MB DDR3 | 16GB DDR3 1600MHz)");
            }
        }
    }

    public string VideoCard
    {
        get
        {
            return this.videoCardField;
        }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Length >= 3 && value.Length < 50)
                {
                    videoCardField = value;
                    isValid = true;
                }
            }

            if (!isValid)
            {
                throw new FormatException(value == null ?
                    "Processor: Invalid VideoCard Name format. Null value." :
                    "Processor: Invalid VideoCard Name format. Invalid Text Length.");
            }
        }
    }

    public string HardDisk
    {
        get
        {
            return this.HDDField;
        }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Length >= 3 && value.Length < 30 &&
                    System.Text.RegularExpressions.Regex.IsMatch(value,
                    @"^([1-9][0-9]*\s*[gbGBmMtT]{2}(\s*[SHDshd]+)*\s*([1-9][0-9]+[RPMrpm]{3})*)$"))
                {
                    HDDField = value.Trim();
                    isValid = true;
                }
            }

            if (!isValid)
            {
                throw new FormatException(value == null ?
                    "RAM: Invalid HDD Field input format. Null value." :
                    "RAM: Invalid HDD Field input format/size. (ex.: 8 GB | 512MB SSD | 16GB HDD 5200RPM)");
            }
        }
    }

    public string Display
    {
        get
        {
            return this.displayField;
        }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Length >= 3 && value.Length < 100)
                {
                    displayField = value;
                    isValid = true;
                }
            }

            if (!isValid)
            {
                throw new FormatException(value == null ?
                    "Processor: Invalid Display format. Null value." :
                    "Processor: Invalid Size of the Display Info.");
            }
        }
    }

    public string BatteryName
    {
        get
        {
            return this.batteryObject.Name;
        }
        set
        {
            bool isValie = false;
            if (value != null)
            {
                if (value.Length > 5 &&
                    value.Length < 50)
                {
                    this.batteryObject.Name = value.Trim();
                    isValie = true;
                }
            }

            if (!isValie)
            {
                throw new FormatException(string.Format("Battery Name: Invalid Input => \"{0}\"", value));
            }
        }
    }

    public double BatteryDurationValue
    {
        get
        {
            return this.batteryObject.UsageDuration;
        }
        set
        {
            if (value > 0d)
            {
                this.batteryObject.UsageDuration = Math.Round(value, 1);
            }
            else
            {
                throw new IndexOutOfRangeException("UsageDuration: Only values bigger than 0 are allowed.");
            }
        }
    }

    public override string ToString()
    {
        string returnText = string.Format("Sample laptop description (full):\nModel: {0},\nPrice: {1} lv.",
            this.Model, this.Price);
        if (manifacturerField != null)
        {
            returnText += string.Format(",\nManifacturer: {0}", this.Manifacturer);
        }
        if (processorField != null)
        {
            returnText += string.Format(",\nProcessor: {0}", this.Processor);
        }
        if (ramField != null)
        {
            returnText += string.Format(",\nRAM: {0}", this.RAM);
        }
        if (videoCardField != null)
        {
            returnText += string.Format(",\nGraphics Card: {0}", this.VideoCard);
        }
        if (HDDField != null)
        {
            returnText += string.Format(",\nHDD: {0}", this.HardDisk);
        }
        if (displayField != null)
        {
            returnText += string.Format(",\nScreen: {0}", this.Display);
        }
        if (batteryObject.Name != null)
        {
            returnText += string.Format(",\nBattery: {0}", this.batteryObject.Name);
        }
        if (batteryObject.UsageDuration != 0d)
        {
            returnText += string.Format(",\nBattery Life: {0} hours.", this.batteryObject.UsageDuration);
        }

        return returnText;
    }

    public string MandatoryOnly()
    {
        if (this.Model != null && this.Price > 0)
        {
            return string.Format("Sample laptop description (mandatory properties only):\nModel: {0}\nPrice: {1} leva",
            this.Model, this.Price);
        }
        else
        {
            throw new FormatException(string.Format(
                "Name or Price Field data is invalid. Name \"{0}\", Price\"{1}\"",
                this.Model, this.Price));
        }
    }
}