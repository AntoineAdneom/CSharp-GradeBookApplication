using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
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

        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
