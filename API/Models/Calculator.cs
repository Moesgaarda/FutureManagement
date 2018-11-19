using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class Calculator{
        public Calculator(){}

        /// <summary>
        /// Constructor for calculator with an id.
        /// Used for getting a calculator.
        /// </summary>
        /// <param name="id">Id of the calculator</param>
        /// <param name="name">Name of the calculator</param>
        /// <param name="number">Calculator number</param>
        public Calculator(int id, string name, int number){
            this.Id = id;
            this.Name = name;
            this.Number = number;
        }

        /// <summary>
        /// Constructor for calculator without an id. 
        /// Used for for creating a calculator.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        public Calculator(string name, int number){
            this.Name = name;
            this.Number = number;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}