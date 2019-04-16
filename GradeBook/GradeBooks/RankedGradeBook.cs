using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            char result = 'F';
            var treshold = (int)Math.Ceiling(Students.Count * .2);
            var listAverageGrades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
            if(averageGrade >= listAverageGrades[treshold - 1])
            {
                result = 'A';
            }
            else if (averageGrade >= listAverageGrades[treshold*2 - 1])
            {
                result = 'B';
            }
            else if(averageGrade >= listAverageGrades[treshold*3 - 1])
            {
                result = 'C';
            }
            else if(averageGrade >= listAverageGrades[treshold*4 - 1])
            {
                result = 'D';
            }

            return result;
        }
    }
}
