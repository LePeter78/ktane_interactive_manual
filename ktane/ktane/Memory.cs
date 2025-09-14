using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktane
{
    internal class Memory
    {
        internal class Stage
        {
            internal int label;
            internal int position;

            internal Stage(int label, int position)
            {
                this.label = label;
                this.position = position;
            }
        }

        protected List<Stage> stages = [];

        public Memory()
        {
            Stage1();
            Stage2();
            Stage3();
            Stage4();
            Stage5();
        }

        private static void ReadInput(ref int display, ref int[] labels)
        {
            ReadInt read;

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Label on button {i + 1}:");
                read = new(1, 4);
                labels[i] = read.num;
            }

            Console.WriteLine("Display:");
            read = new(1, 4);
            display = read.num;
        }
        private void AddStage(int label, int pos)
        {
            this.stages.Add(new Stage(label, pos));
        }
        private static int GetCurrentPosition(int currentLabel, int[] labels)
        {
            for (int i = 0; i < labels.Length; i++)
                if (currentLabel == labels[i]) return i + 1;
            throw new ArgumentException();
        }
        private void Position(int pos, int[] labels)
        {
            Console.WriteLine(labels[pos - 1]);
            AddStage(labels[pos - 1], pos);
        }
        private void Label(int label, int[] labels)
        {
            Console.WriteLine(label);
            AddStage(label, GetCurrentPosition(label, labels));
        }
        private void PreviousPosition(int stageNum, int[] labels)
        {
            Console.WriteLine(labels[this.stages[stageNum - 1].position - 1]);
            AddStage(labels[this.stages[stageNum - 1].position - 1], this.stages[stageNum - 1].position);
        }
        private void PreviousLabel(int stageNum, int[] labels)
        {
            Console.WriteLine(this.stages[stageNum - 1].label);
            AddStage(this.stages[stageNum - 1].label, GetCurrentPosition(this.stages[stageNum - 1].label, labels));
        }
        private void Stage1()
        {
            Console.WriteLine("Stage 1:");
            int display = 0;
            int[] labels = new int[4];
            ReadInput(ref display, ref labels);

            Console.Clear();
            Console.Write("Press ");
            switch (display)
            {
                case 1:
                    Position(2, labels);
                    break;
                case 2:
                    Position(2, labels);
                    break;
                case 3:
                    Position(3, labels);
                    break;
                case 4:
                    Position(4, labels);
                    break;
            }
        }
        private void Stage2()
        {
            Console.WriteLine("\nStage 2:");
            int display = 0;
            int[] labels = new int[4];
            ReadInput(ref display, ref labels);

            Console.Clear();
            Console.Write("Press ");
            switch (display)
            {
                case 1:
                    Label(4, labels);
                    break;
                case 2:
                    PreviousPosition(1, labels);
                    break;
                case 3:
                    Position(1, labels);
                    break;
                case 4:
                    PreviousPosition(1, labels);
                    break;
            }
        }
        private void Stage3()
        {
            Console.WriteLine("\nStage 3:");
            int display = 0;
            int[] labels = new int[4];
            ReadInput(ref display, ref labels);

            Console.Clear();
            Console.Write("Press ");
            switch (display)
            {
                case 1:
                    PreviousLabel(2, labels);
                    break;
                case 2:
                    PreviousLabel(1, labels);
                    break;
                case 3:
                    Position(3, labels);
                    break;
                case 4:
                    Label(4, labels);
                    break;
            }
        }
        private void Stage4()
        {
            Console.WriteLine("\nStage 4:");
            int display = 0;
            int[] labels = new int[4];
            ReadInput(ref display, ref labels);

            Console.Clear();
            Console.Write("Press ");
            switch (display)
            {
                case 1:
                    PreviousPosition(1, labels);
                    break;
                case 2:
                    Position(1, labels);
                    break;
                case 3:
                    PreviousPosition(2, labels);
                    break;
                case 4:
                    PreviousPosition(2, labels);
                    break;
            }
        }
        private void Stage5()
        {
            Console.WriteLine("\nStage 5:");
            int display = 0;
            int[] labels = new int[4];
            ReadInput(ref display, ref labels);

            Console.Clear();
            Console.Write("Press ");
            switch (display)
            {
                case 1:
                    PreviousLabel(1, labels);
                    break;
                case 2:
                    PreviousLabel(2, labels);
                    break;
                case 3:
                    PreviousLabel(4, labels);
                    break;
                case 4:
                    PreviousLabel(3, labels);
                    break;
            }
        }
    }
}
