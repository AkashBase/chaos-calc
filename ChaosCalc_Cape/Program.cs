using System;

namespace ChaosCalc
{
    class Program
    {



        static void Main(string[] args)
        {
           
            Program p = new Program();
            p.checkprice();
        }

        public double[] shoe_price = {
            0,// 0
0,// 1
0,// 2
0.15,// 3
0.3,// 4
0.5,// 5
1.1,// 6
2,// 7
2.8,// 8
3.8,// 9
5.5,// 10
7,// 11
9,// 12
12,// 13
15,// 14
20,// 15
25.5,// 16
32.5,// 17
46,// 18
57,// 19
69,// 20
99,// 21
120,// 22
150,// 23
180,// 24
210,// 25
240,// 26
270,// 27
300 //  28
        };

        //reworked for shoes

        public double[] capeslots0 =
        {
0,// 0
0,// 1
0,// 2
1,// 3
5,// 4
30,// 5
100,// 6
150,// 7
250,// 8
340,// 9
600,// 10
800,// 11
1100,// 12
1600,// 13
1900,// 14
2500,// 15
3200,// 16
4500,// 17
6000,// 18
8000,// 19
10000,// 20
12000,// 21
14000,// 22
17000,// 23
20000,// 24
24000,// 25
29000,// 26
35000,// 27
42000,// 28
50000// 29

        };

        //capes in coin


        /*
 0,// 0
0,// 1
0,// 2
1,// 3
5,// 4
30,// 5
100,// 6
150,// 7
250,// 8
340,// 9
625,// 10
800,// 11
1100,// 12
1600,// 13
1900,// 14
2500,// 15
3200,// 16
4500,// 17
6000,// 18
8000,// 19
10000,// 20
12000,// 21
14000,// 22
17000,// 23
20000,// 24
24000,// 25
29000,// 26
35000,// 27
42000,// 28
50000// 29

         */

        public double CS_Price = 103;
        public double WS_Price = 103;

    public void checkprice(/*string armor, int attack, int slots*/)
        {
            //array for cape(0/1...24/1)
            double[] capeslots1 = new double[25];

            cape_value[] cape1 = Calc_value_slot1(capeslots1);

            for(int i = 0; i<cape1.Length; i++)
            {
                Console.WriteLine("Cape Attack: " + i + " Slots: " + cape1[i].slots + " Max Value: " + cape1[i].value + " Method: " + cape1[i].method);
            }

            cape_value[] cape2 = Calc_value_slot2(cape1);
            for (int i = 0; i < cape2.Length; i++)
            {
                Console.WriteLine("Cape Attack: " + i + " Slots: " + cape2[i].slots + " Max Value: " + cape2[i].value + " Method: " + cape2[i].method);
            }

            cape_value[] cape3 = Calc_value_slot3(cape2);
            for (int i = 0; i < cape3.Length; i++)
            {
                Console.WriteLine("Cape Attack: " + i + " Slots: " + cape3[i].slots + " Max Value: " + cape3[i].value + " Method: " + cape3[i].method);
            }

            cape_value[] cape4 = Calc_value_slot4(cape3);
            for (int i = 0; i < cape4.Length; i++)
            {
                Console.WriteLine("Cape Attack: " + i + " Slots: " + cape4[i].slots + " Max Value: " + cape4[i].value + " Method: " + cape4[i].method);
            }

            cape_value[] cape5 = Calc_value_slot5(cape4);
            for (int i = 0; i < cape5.Length; i++)
            {
                Console.WriteLine("Cape Attack: " + i + " Slots: " + cape5[i].slots + " Max Value: " + cape5[i].value + " Method: " + cape5[i].method);
            }


        }





        public cape_value[] Calc_value_slot1(double[] capeslots1)
        {
            cape_value[] cape1 = new cape_value[capeslots1.Length];
            double[] capeslots1_cs = new double[capeslots1.Length]; 
            double[] capeslots1_csws = new double[capeslots1.Length];
            //populate values for capeslots1_cs

            for (int i = 0; i < capeslots1_cs.Length; i++)
            {
                if (i == 0)
                {
                    capeslots1_cs[i] = 0 - CS_Price;
                }
                else
                {
                    var expected_value = 0.0;

                    for (int j = -5; j < 6; j++)
                    {
                        var cape_attack = i + j;
                        Double chaos_prob = (1.0 / 11.0) * (6.0 / 10.0);

                        if (cape_attack < 0)
                        {
                            cape_attack = 0;
                        }

                        if (j == 0)
                        {
                            chaos_prob = (1.0 / 11.0) * (6.0 / 10.0) + (4.0 / 10.0);
                        }


                        expected_value = expected_value + chaos_prob * capeslots0[cape_attack];

                        //Console.WriteLine("Chaos_Prob: " + chaos_prob + " cape attack: " + cape_attack + " ev: " + chaos_prob * capeslots0[cape_attack]);


                    }


                    capeslots1_cs[i] = expected_value - CS_Price;


                }

               // Console.WriteLine("cape attack: " + i + " slots: 1" + " expected value: " + capeslots1_cs[i]);

            }



            //populate values for CS_WS

            for (int i2 = 0; i2 < capeslots1_csws.Length; i2++)
            {
                if (i2 == 0)
                {
                    capeslots1_csws[i2] = -(CS_Price + WS_Price) / 0.6;
                }
                else
                {
                    var expected_value2 = 0.0;

                    for (int j2 = -5; j2 < 6; j2++)
                    {
                        var cape_attack2 = i2 + j2;
                        Double chaos_prob = (1.0 / 11.0);

                        if (cape_attack2 < 0)
                        {
                            cape_attack2 = 0;
                        }



                        expected_value2 = expected_value2 + chaos_prob * capeslots0[cape_attack2];

                        // Console.WriteLine("Chaos_Prob: " + chaos_prob + " cape attack: " + cape_attack2 + " ev: " + chaos_prob * capeslots0[cape_attack2]);


                    }


                    capeslots1_csws[i2] = expected_value2 - (CS_Price + WS_Price) / 0.6;


                }

                //Console.WriteLine("cape attack: " + i2 + " slots: 1" + " expected value: " + capeslots1_csws[i2]);

            }


            //create cape_values array object containing best value and method
            for (int i3 = 0; i3 < capeslots1.Length; i3++)
            {
                cape_value cv = new cape_value();
                var cs_value = capeslots1_cs[i3];
                var csws_value = capeslots1_csws[i3];
                var base_value = capeslots0[i3];

                if(base_value > csws_value & base_value > cs_value)
                {
                    cv.value = base_value;
                    cv.method = "stop scrolling";
                }
                else if (csws_value > base_value & csws_value > cs_value)
                {
                    cv.value = csws_value;
                    cv.method = "csws";
                }
                else
                {
                    cv.value = cs_value;
                    cv.method = "cs";
                }

                cv.slots = 1;

                cape1[i3] = cv;

            }



            return cape1;
        }


        public cape_value[] Calc_value_slot2(cape_value[] cape1)
        {
            cape_value[] cape2 = new cape_value[cape1.Length-5];
            double[] capeslots2_cs = new double[cape1.Length-5];
            double[] capeslots2_csws = new double[cape1.Length-5];

            //calculate for CS
            for (int i = 0; i < capeslots2_cs.Length; i++)
            {
                if (i == 0)
                {
                    capeslots2_cs[i] = 0 - CS_Price;
                }
                else
                {
                    var expected_value = 0.0;

                    for (int j = -5; j < 6; j++)
                    {
                        var cape_attack = i + j;
                        Double chaos_prob = (1.0 / 11.0) * (6.0 / 10.0);

                        if (cape_attack < 0)
                        {
                            cape_attack = 0;
                        }

                        if (j == 0)
                        {
                            chaos_prob = (1.0 / 11.0) * (6.0 / 10.0) + (4.0 / 10.0);
                        }


                        expected_value = expected_value + chaos_prob * cape1[cape_attack].value;



                    }


                    capeslots2_cs[i] = expected_value - CS_Price;


                }


            }



            //populate values for CS_WS

            for (int i2 = 0; i2 < capeslots2_csws.Length; i2++)
            {
                if (i2 == 0)
                {
                    capeslots2_csws[i2] = -(CS_Price + WS_Price) / 0.6;
                }
                else
                {
                    var expected_value2 = 0.0;

                    for (int j2 = -5; j2 < 6; j2++)
                    {
                        var cape_attack2 = i2 + j2;
                        Double chaos_prob = (1.0 / 11.0);

                        if (cape_attack2 < 0)
                        {
                            cape_attack2 = 0;
                        }



                        expected_value2 = expected_value2 + chaos_prob * cape1[cape_attack2].value;

                        // Console.WriteLine("Chaos_Prob: " + chaos_prob + " cape attack: " + cape_attack2 + " ev: " + chaos_prob * capeslots0[cape_attack2]);


                    }


                    capeslots2_csws[i2] = expected_value2 - (CS_Price + WS_Price) / 0.6;


                }

                //Console.WriteLine("cape attack: " + i2 + " slots: 1" + " expected value: " + capeslots1_csws[i2]);

            }


            //create cape_values array object containing best value and method
            for (int i3 = 0; i3 < cape1.Length - 5; i3++)
            {
                cape_value cv = new cape_value();
                var cs_value = capeslots2_cs[i3];
                var csws_value = capeslots2_csws[i3];
                var base_value = cape1[i3].value;

                if (base_value > csws_value & base_value > cs_value)
                {
                    cv.value = base_value;
                    cv.method = "stop scrolling";
                }
                else if (csws_value > base_value & csws_value > cs_value)
                {
                    cv.value = csws_value;
                    cv.method = "csws";
                }
                else
                {
                    cv.value = cs_value;
                    cv.method = "cs";
                }

                cv.slots = 2;

                cape2[i3] = cv;

            }





            return cape2;
        }







        public cape_value[] Calc_value_slot3(cape_value[] cape2)
        {
            cape_value[] cape3 = new cape_value[cape2.Length - 5];
            double[] capeslots3_cs = new double[cape2.Length - 5];
            double[] capeslots3_csws = new double[cape2.Length - 5];

            //calculate for CS
            for (int i = 0; i < capeslots3_cs.Length; i++)
            {
                if (i == 0)
                {
                    capeslots3_cs[i] = 0 - CS_Price;
                }
                else
                {
                    var expected_value = 0.0;

                    for (int j = -5; j < 6; j++)
                    {
                        var cape_attack = i + j;
                        Double chaos_prob = (1.0 / 11.0) * (6.0 / 10.0);

                        if (cape_attack < 0)
                        {
                            cape_attack = 0;
                        }

                        if (j == 0)
                        {
                            chaos_prob = (1.0 / 11.0) * (6.0 / 10.0) + (4.0 / 10.0);
                        }


                        expected_value = expected_value + chaos_prob * cape2[cape_attack].value;



                    }


                    capeslots3_cs[i] = expected_value - CS_Price;


                }


            }



            //populate values for CS_WS

            for (int i2 = 0; i2 < capeslots3_csws.Length; i2++)
            {
                if (i2 == 0)
                {
                    capeslots3_csws[i2] = -(CS_Price + WS_Price) / 0.6;
                }
                else
                {
                    var expected_value2 = 0.0;

                    for (int j2 = -5; j2 < 6; j2++)
                    {
                        var cape_attack3 = i2 + j2;
                        Double chaos_prob = (1.0 / 11.0);

                        if (cape_attack3 < 0)
                        {
                            cape_attack3 = 0;
                        }



                        expected_value2 = expected_value2 + chaos_prob * cape2[cape_attack3].value;

                        // Console.WriteLine("Chaos_Prob: " + chaos_prob + " cape attack: " + cape_attack2 + " ev: " + chaos_prob * capeslots0[cape_attack2]);


                    }


                    capeslots3_csws[i2] = expected_value2 - (CS_Price + WS_Price) / 0.6;


                }

                //Console.WriteLine("cape attack: " + i2 + " slots: 1" + " expected value: " + capeslots1_csws[i2]);

            }


            //create cape_values array object containing best value and method
            for (int i3 = 0; i3 < cape2.Length - 5; i3++)
            {
                cape_value cv = new cape_value();
                var cs_value = capeslots3_cs[i3];
                var csws_value = capeslots3_csws[i3];
                var base_value = cape2[i3].value;

                if (base_value > csws_value & base_value > cs_value)
                {
                    cv.value = base_value;
                    cv.method = "stop scrolling";
                }
                else if (csws_value > base_value & csws_value > cs_value)
                {
                    cv.value = csws_value;
                    cv.method = "csws";
                }
                else
                {
                    cv.value = cs_value;
                    cv.method = "cs";
                }

                cv.slots = 3;

                cape3[i3] = cv;

            }





            return cape3;
        }



        public cape_value[] Calc_value_slot4(cape_value[] cape3)
        {
            cape_value[] cape4 = new cape_value[cape3.Length - 5];
            double[] capeslots4_cs = new double[cape3.Length - 5];
            double[] capeslots4_csws = new double[cape3.Length - 5];

            //calculate for CS
            for (int i = 0; i < capeslots4_cs.Length; i++)
            {
                if (i == 0)
                {
                    capeslots4_cs[i] = 0 - CS_Price;
                }
                else
                {
                    var expected_value = 0.0;

                    for (int j = -5; j < 6; j++)
                    {
                        var cape_attack = i + j;
                        Double chaos_prob = (1.0 / 11.0) * (6.0 / 10.0);

                        if (cape_attack < 0)
                        {
                            cape_attack = 0;
                        }

                        if (j == 0)
                        {
                            chaos_prob = (1.0 / 11.0) * (6.0 / 10.0) + (4.0 / 10.0);
                        }


                        expected_value = expected_value + chaos_prob * cape3[cape_attack].value;



                    }


                    capeslots4_cs[i] = expected_value - CS_Price;


                }


            }



            //populate values for CS_WS

            for (int i2 = 0; i2 < capeslots4_csws.Length; i2++)
            {
                if (i2 == 0)
                {
                    capeslots4_csws[i2] = -(CS_Price + WS_Price) / 0.6;
                }
                else
                {
                    var expected_value2 = 0.0;

                    for (int j2 = -5; j2 < 6; j2++)
                    {
                        var cape_attack3 = i2 + j2;
                        Double chaos_prob = (1.0 / 11.0);

                        if (cape_attack3 < 0)
                        {
                            cape_attack3 = 0;
                        }



                        expected_value2 = expected_value2 + chaos_prob * cape3[cape_attack3].value;

                        // Console.WriteLine("Chaos_Prob: " + chaos_prob + " cape attack: " + cape_attack2 + " ev: " + chaos_prob * capeslots0[cape_attack2]);


                    }


                    capeslots4_csws[i2] = expected_value2 - (CS_Price + WS_Price) / 0.6;


                }

                //Console.WriteLine("cape attack: " + i2 + " slots: 1" + " expected value: " + capeslots1_csws[i2]);

            }


            //create cape_values array object containing best value and method
            for (int i3 = 0; i3 < cape3.Length - 5; i3++)
            {
                cape_value cv = new cape_value();
                var cs_value = capeslots4_cs[i3];
                var csws_value = capeslots4_csws[i3];
                var base_value = cape3[i3].value;

                if (base_value > csws_value & base_value > cs_value)
                {
                    cv.value = base_value;
                    cv.method = "stop scrolling";
                }
                else if (csws_value > base_value & csws_value > cs_value)
                {
                    cv.value = csws_value;
                    cv.method = "csws";
                }
                else
                {
                    cv.value = cs_value;
                    cv.method = "cs";
                }

                cv.slots = 4;

                cape4[i3] = cv;

            }





            return cape4;
        }



        public cape_value[] Calc_value_slot5(cape_value[] cape4)
        {
            cape_value[] cape5 = new cape_value[cape4.Length - 5];
            double[] capeslots5_cs = new double[cape4.Length - 5];
            double[] capeslots5_csws = new double[cape4.Length - 5];

            //calculate for CS
            for (int i = 0; i < capeslots5_cs.Length; i++)
            {
                if (i == 0)
                {
                    capeslots5_cs[i] = 0 - CS_Price;
                }
                else
                {
                    var expected_value = 0.0;

                    for (int j = -5; j < 6; j++)
                    {
                        var cape_attack = i + j;
                        Double chaos_prob = (1.0 / 11.0) * (6.0 / 10.0);

                        if (cape_attack < 0)
                        {
                            cape_attack = 0;
                        }

                        if (j == 0)
                        {
                            chaos_prob = (1.0 / 11.0) * (6.0 / 10.0) + (4.0 / 10.0);
                        }


                        expected_value = expected_value + chaos_prob * cape4[cape_attack].value;



                    }


                    capeslots5_cs[i] = expected_value - CS_Price;


                }


            }



            //populate values for CS_WS

            for (int i2 = 0; i2 < capeslots5_csws.Length; i2++)
            {
                if (i2 == 0)
                {
                    capeslots5_csws[i2] = -(CS_Price + WS_Price) / 0.6;
                }
                else
                {
                    var expected_value2 = 0.0;

                    for (int j2 = -5; j2 < 6; j2++)
                    {
                        var cape_attack3 = i2 + j2;
                        Double chaos_prob = (1.0 / 11.0);

                        if (cape_attack3 < 0)
                        {
                            cape_attack3 = 0;
                        }



                        expected_value2 = expected_value2 + chaos_prob * cape4[cape_attack3].value;

                        // Console.WriteLine("Chaos_Prob: " + chaos_prob + " cape attack: " + cape_attack2 + " ev: " + chaos_prob * capeslots0[cape_attack2]);


                    }


                    capeslots5_csws[i2] = expected_value2 - (CS_Price + WS_Price) / 0.6;


                }

                //Console.WriteLine("cape attack: " + i2 + " slots: 1" + " expected value: " + capeslots1_csws[i2]);

            }


            //create cape_values array object containing best value and method
            for (int i3 = 0; i3 < cape5.Length; i3++)
            {
                cape_value cv = new cape_value();
                var cs_value = capeslots5_cs[i3];
                var csws_value = capeslots5_csws[i3];
                var base_value = cape4[i3].value;

                if (base_value > csws_value & base_value > cs_value)
                {
                    cv.value = base_value;
                    cv.method = "stop scrolling";
                }
                else if (csws_value > base_value & csws_value > cs_value)
                {
                    cv.value = csws_value;
                    cv.method = "csws";
                }
                else
                {
                    cv.value = cs_value;
                    cv.method = "cs";
                }

                cv.slots = 5;

                cape5[i3] = cv;

            }





            return cape5;
        }


        public class cape_value
        {
            public string method;
            public double value;
            public int slots;
        };

    }

}
