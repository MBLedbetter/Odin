using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OdinServices
{
    public class TextGeneratorService
    {
        #region Events

        /// <summary>
        ///     This event is raised when a property of this object is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Events

        #region Properties

        public static Random random = new Random();

        public ObservableCollection<string> compoundNoun1A
        {
            get
            {
                return _compoundNoun1A;
            }
            set
            {
                _compoundNoun1A = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("compoundNoun1A"));
                }
            }
        }
        private ObservableCollection<string> _compoundNoun1A = new ObservableCollection<string>();

        public ObservableCollection<string> compoundNoun1B
        {
            get
            {
                return _compoundNoun1B;
            }
            set
            {
                _compoundNoun1B = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("compoundNoun1B"));
                }
            }
        }
        private ObservableCollection<string> _compoundNoun1B = new ObservableCollection<string>();

        public ObservableCollection<string> CompoundNoun1C
        {
            get
            {
                return _compoundNoun1C;
            }
            set
            {
                _compoundNoun1C = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CompoundNoun1C"));
                }
            }
        }
        private ObservableCollection<string> _compoundNoun1C = new ObservableCollection<string>();

        public ObservableCollection<string> CompoundVerb1A
        {
            get
            {
                return _compoundVerb1A;
            }
            set
            {
                _compoundVerb1A = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CompoundVerb1A"));
                }
            }
        }
        private ObservableCollection<string> _compoundVerb1A = new ObservableCollection<string>();

        public ObservableCollection<string> CompoundVerb1B
        {
            get
            {
                return _compoundVerb1B;
            }
            set
            {
                _compoundVerb1B = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CompoundVerb1B"));
                }
            }
        }
        private ObservableCollection<string> _compoundVerb1B = new ObservableCollection<string>();

        public ObservableCollection<string> CompoundVerb1C
        {
            get
            {
                return _compoundVerb1C;
            }
            set
            {
                _compoundVerb1C = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CompoundVerb1C"));
                }
            }
        }
        private ObservableCollection<string> _compoundVerb1C = new ObservableCollection<string>();

        public ObservableCollection<string> customerNouns
        {
            get
            {
                return _customerNouns;
            }
            set
            {
                _customerNouns = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("customerNouns"));
                }
            }
        }
        private ObservableCollection<string> _customerNouns = new ObservableCollection<string>();

        public ObservableCollection<string> FantasyLocation
        {
            get
            {
                return _fantasyLocation;
            }
            set
            {
                _fantasyLocation = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("FantasyLocation"));
                }
            }
        }
        private ObservableCollection<string> _fantasyLocation = new ObservableCollection<string>();

        public ObservableCollection<string> FantasyVerb
        {
            get
            {
                return _fantasyVerb;
            }
            set
            {
                _fantasyVerb = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("FantasyVerb"));
                }
            }
        }
        private ObservableCollection<string> _fantasyVerb = new ObservableCollection<string>();

        public ObservableCollection<string> HeroActions
        {
            get
            {
                return _heroActions;
            }
            set
            {
                _heroActions = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("HeroActions"));
                }
            }
        }
        private ObservableCollection<string> _heroActions = new ObservableCollection<string>();

        public ObservableCollection<string> ItemAdjectives
        {
            get
            {
                return _itemAdjectives;
            }
            set
            {
                _itemAdjectives = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemAdjectives"));
                }
            }
        }
        private ObservableCollection<string> _itemAdjectives = new ObservableCollection<string>();

        public ObservableCollection<string> SentenceOutlines
        {
            get
            {
                return _sentenceOutlines;
            }
            set
            {
                _sentenceOutlines = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SentenceOutlines"));
                }
            }
        }
        private ObservableCollection<string> _sentenceOutlines = new ObservableCollection<string>();

        public ObservableCollection<string> StarWarsIntros
        {
            get
            {
                return _starWarsIntros;
            }
            set
            {
                _starWarsIntros = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("StarWarsIntros"));
                }
            }
        }
        private ObservableCollection<string> _starWarsIntros = new ObservableCollection<string>();

        #endregion // Properties

        #region Methods

        #region Methods.Generate

        public string GenerateSentence(ItemObject item)
        {
            string sentence = RetrieveSentenceOutline();
            sentence = sentence.Replace("{%compoundNoun1A%}", RetrievecompoundNoun1A());
            sentence = sentence.Replace("{%compoundNoun1B%}", RetrievecompoundNoun1B());
            sentence = sentence.Replace("{%compoundNoun1C%}", RetrieveCompoundNoun1C());
            sentence = sentence.Replace("{%compoundVerb1A%}", RetrieveCompoundVerb1A());
            sentence = sentence.Replace("{%compoundVerb1B%}", RetrieveCompoundVerb1B());
            sentence = sentence.Replace("{%compoundVerb1C%}", RetrieveCompoundVerb1C());
            sentence = sentence.Replace("{%customerNoun%}", RetrieveCustomerNoun());
            sentence = sentence.Replace("{%fantasyLocation%}", RetrieveFantasyLocation());
            sentence = sentence.Replace("{%fantasyVerb%}", RetrieveFantasyVerb());
            sentence = sentence.Replace("{%heroAction%}", RetrieveHeroAction());
            sentence = sentence.Replace("{%itemAdjective1%}", RetrieveItemAdjective());
            sentence = sentence.Replace("{%starWarsIntro%}", RetrieveStarWarsIntro());
            sentence = sentence.Replace("{%license%}", item.License);
            sentence = sentence.Replace("{%property%}", item.Property);
            sentence = sentence.Replace("{%title%}", item.Title);
            sentence = sentence.Replace("{%productType%}", item.ItemGroup.ToLower());
            return sentence;
        }

        #endregion // Methods.Generate

        #region Methods.Populate

        public void Populate()
        {
            PopulatecompoundNoun1A();
            PopulateCompoundNoun1B();
            PopulateCompoundNoun1C();
            PopulateCompoundVerb1A();
            PopulateCompoundVerb1B();
            PopulateCompoundVerb1C();
            PopulateCustomerNouns();
            PopulateFantasyLocation();
            PopulateFantasyVerb();
            PopulateHeroAction();
            PopulateItemAdjectives1();
            PopulateSentenceOutlines();
            PopulateStarWarsIntros();
        }

        public void PopulatecompoundNoun1A()
        {
            this.compoundNoun1A.Add("perfect");
            this.compoundNoun1A.Add("standout");
            this.compoundNoun1A.Add("must-have");
            this.compoundNoun1A.Add("ideal");
        }

        public void PopulateCompoundNoun1B()
        {
            this.compoundNoun1B.Add("item");
            this.compoundNoun1B.Add("decoration");
            this.compoundNoun1B.Add("centerpiece");
            this.compoundNoun1B.Add("piece");
        }

        public void PopulateCompoundNoun1C()
        {
            this.CompoundNoun1C.Add("finishing touch");
            this.CompoundNoun1C.Add("focal point");
        }

        public void PopulateCompoundVerb1A()
        {
            this.CompoundVerb1A.Add("sure");
            this.CompoundVerb1A.Add("certain");
            this.CompoundVerb1A.Add("guaranteed");
        }

        public void PopulateCompoundVerb1B()
        {
            this.CompoundVerb1B.Add("delight");
            this.CompoundVerb1B.Add("impress");
            this.CompoundVerb1B.Add("inspire");
        }

        public void PopulateCompoundVerb1C()
        {
            this.CompoundVerb1C.Add("designed for");
            this.CompoundVerb1C.Add("perfect for");
        }

        public void PopulateCustomerNouns()
        {
            this.customerNouns.Add("fan");
            this.customerNouns.Add("enthusiast");
            this.customerNouns.Add("lover");
        }

        public void PopulateFantasyLocation()
        {
            this.FantasyLocation.Add("a land of magic");
            this.FantasyLocation.Add("a land of fantasy");
            this.FantasyLocation.Add("a world of fairy tales");
            this.FantasyLocation.Add("a place of fantasy");
            this.FantasyLocation.Add("a world of fantasy");
            this.FantasyLocation.Add("a place of magic");
            this.FantasyLocation.Add("a land of dreams and fantasy");
        }

        public void PopulateFantasyVerb()
        {
            this.FantasyVerb.Add("take you away");
            this.FantasyVerb.Add("teleport you");
            this.FantasyVerb.Add("transport you");
            this.FantasyVerb.Add("take anyone away");
        }

        public void PopulateHeroAction()
        {
            this.HeroActions.Add("inspire you to greatness");
            this.HeroActions.Add("propel any room to greatness");
            this.HeroActions.Add("empower you to greatness");
            this.HeroActions.Add("push you to greatness");
            this.HeroActions.Add("be the star feature in any superhero's room");
            this.HeroActions.Add("be the {%compoundNoun1A%} {%compoundNoun1B%} in any superhero's room");
            this.HeroActions.Add("be the {%compoundNoun1B%} in any superhero's room");
            this.HeroActions.Add("carry any room to greatness");
            this.HeroActions.Add("always save the day");
            this.HeroActions.Add("drive you to greatness");
        }

        public void PopulateItemAdjectives1()
        {
            this.ItemAdjectives.Add("beautiful");
            this.ItemAdjectives.Add("exquisite");
            this.ItemAdjectives.Add("incredible");
            this.ItemAdjectives.Add("inspirational");
            this.ItemAdjectives.Add("marvellous");
            this.ItemAdjectives.Add("remarkable");
            this.ItemAdjectives.Add("wonderful");
        }

        public void PopulateSentenceOutlines()
        {
            this.SentenceOutlines.Add("A {%compoundNoun1A%} for any {%license%} {%customerNoun%}, the {%title%} {%productType%} will be the {%compoundNoun1C%} in any room");
            this.SentenceOutlines.Add("A {%compoundNoun1A%} for any {%license%} {%customerNoun%}, the {%title%} {%productType%} will be the {%compoundNoun1A%} {%compoundNoun1B%} in any room");
            this.SentenceOutlines.Add("Don't miss out on this {%itemAdjective1%} piece.");
            this.SentenceOutlines.Add("Don't miss out on this {%itemAdjective1%} piece from the {%property} collection.");
            this.SentenceOutlines.Add("You will love this {%itemAdjective1%} piece.");
            this.SentenceOutlines.Add("You will love this {%itemAdjective1%} piece from the {%property%} collection.");
            this.SentenceOutlines.Add("Perfect for you or as a gift for a loved one, this {%itemAdjective1%} piece is {%compoundVerb1A%} to {%compoundVerb1B%}");
            this.SentenceOutlines.Add("Perfect for you or as a gift for a loved one, this {%itemAdjective1%} piece from the {%property%} collection is {%compoundVerb1A%} to {%compoundVerb1B%}");
            this.SentenceOutlines.Add("Perfect for any {%license%} {%customerNoun%}, the {%title%} {%productType%} will be the {%compoundNoun1A%} {%compoundNoun1B%} in any room");
            this.SentenceOutlines.Add("Perfect for any {%license%} {%customerNoun%}, the {%title%} {%productType%} will be the {%compoundNoun1C%} in any room");
            this.SentenceOutlines.Add("The {%title%} {%productType%} is the {%compoundNoun1A%} {%compoundNoun1B%} for any {%license%} {%customerNoun%}.");
            this.SentenceOutlines.Add("The {%title%} {%productType%} is {%compoundNoun1A%} for all your {%license%} {%customerNoun%}s.");
            this.SentenceOutlines.Add("The {%license%} {%title%} {%productType%} is {%compoundVerb1C%} all your {%license%} {%cusomterNoun%}s");

            /* Star Wars */

            /* Super Hero */
            this.SentenceOutlines.Add("Save the day with the {%license%} {%title%} {%productType%}.");
            this.SentenceOutlines.Add("This {%productType%}, from the {%property%} collection, will {%heroAction%}");
            this.SentenceOutlines.Add("This {%productType%}, part of the the {%property%} collection, will {%heroAction%}");
            this.SentenceOutlines.Add("Part of the the {%property%} collection, this {%productType%} will {%heroAction%}");
            this.SentenceOutlines.Add("From the {%property%} collection, this {%productType%} will {%heroAction%}");
            this.SentenceOutlines.Add("This {%license%} {%title%} {%productType%} will {%heroAction%}");

            /*Fantasy*/
            this.SentenceOutlines.Add("From the {%property%} collection, this {%productType%} is {%compoundVerb1A%} to {%fantasyVerb%} to {%fantasyLocation%}");
            this.SentenceOutlines.Add("An item in the {%property%} collection, this {%productType%} is {%compoundVerb1A%} to {%fantasyVerb%} to {%fantasyLocation%}");
            this.SentenceOutlines.Add("Part of the the {%property%} collection, this {%productType%} is {%compoundVerb1A%} to {%fantasyVerb%} to {%fantasyLocation%}");
            this.SentenceOutlines.Add("Travel to {%fantasyLocation%} with this {%itemAdjective1%} {%productType%} from the {%property%} collection");

        }

        public void PopulateStarWarsIntros()
        {
            this.StarWarsIntros.Add("The force is strong with this one!");
            this.StarWarsIntros.Add("This {%productType%} could be your only hope!");
        }

        #endregion // Methods.Populate

        #region Methods.Retrieve

        // compoundNoun1A
        public string RetrievecompoundNoun1A()
        {
            int position = random.Next(0, this.compoundNoun1A.Count - 1);
            return this.compoundNoun1A[position];
        }
        //  compoundNoun1B
        public string RetrievecompoundNoun1B()
        {
            int position = random.Next(0, this.compoundNoun1B.Count - 1);
            return this.compoundNoun1B[position];
        }
        // CompoundNoun1C
        public string RetrieveCompoundNoun1C()
        {
            int position = random.Next(0, this.CompoundNoun1C.Count - 1);
            return this.CompoundNoun1C[position];
        }
        // CompoundVerb1A
        public string RetrieveCompoundVerb1A()
        {
            int position = random.Next(0, this.CompoundVerb1A.Count - 1);
            return this.CompoundVerb1A[position];
        }
        // CompoundVerb1B
        public string RetrieveCompoundVerb1B()
        {
            int position = random.Next(0, this.CompoundVerb1B.Count - 1);
            return this.CompoundVerb1B[position];
        }
        // CompoundVerb1C
        public string RetrieveCompoundVerb1C()
        {
            int position = random.Next(0, this.CompoundVerb1C.Count - 1);
            return this.CompoundVerb1C[position];
        }

        // customerNouns
        public string RetrieveCustomerNoun()
        {
            int position = random.Next(0, this.customerNouns.Count - 1);
            return this.customerNouns[position];
        }
        // FantasyLocation
        public string RetrieveFantasyLocation()
        {
            int position = random.Next(0, this.FantasyLocation.Count - 1);
            return this.FantasyLocation[position];
        }
        // FantasyVerb
        public string RetrieveFantasyVerb()
        {
            int position = random.Next(0, this.FantasyVerb.Count - 1);
            return this.FantasyVerb[position];
        }
        // HeroActions
        public string RetrieveHeroAction()
        {
            int position = random.Next(0, this.HeroActions.Count - 1);
            return this.HeroActions[position];
        }
        // ItemAdjectives
        public string RetrieveItemAdjective()
        {
            int position = random.Next(0, this.ItemAdjectives.Count - 1);
            return this.ItemAdjectives[position];
        }
        // SentenceOutlines
        public string RetrieveSentenceOutline()
        {
            int position = random.Next(0, this.SentenceOutlines.Count - 1);
            return this.SentenceOutlines[position];
        }
        // StarWarsIntros
        public string RetrieveStarWarsIntro()
        {
            int position = random.Next(0, this.StarWarsIntros.Count - 1);
            return this.StarWarsIntros[position];
        }


        #endregion // Methods.Retrieve

        #endregion // Methods

        #region Constructor
        public TextGeneratorService()
        {
            Populate();
        }
        #endregion // Constructor
    }
}
