﻿/*
   Copyright 2011 Print Printdev@gmail.com

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintHost.model
{
    public class LogLine
    {
        public string text;
        public bool response; // is it response or send data
        public int level = 0; // Info level 0 = normal, 1 = warning, 2 = error, 3 = info, 4 = Skeinforge
        public DateTime time;

        public LogLine(string _text, bool _response, int _level)
        {
            time = DateTime.Now;
            text = Time()+" : "+_text;
            response = _response;
            level = _level;
        }
        public string Time()
        {
            return time.Hour.ToString("00") + ":" + time.Minute.ToString("00") + ":" +
                time.Second.ToString("00") + "." + time.Millisecond.ToString("000");
        }
    }
    public class RLog
    {
        public static void info(string text)
        {
            Main.conn.log(text, false, 3);
        }
        public static void message(string text)
        {
            Main.conn.log(text, false, 0);
        }
        public static void warning(string text)
        {
            Main.conn.log(text, false, 1);
        }
        public static void error(string text)
        {
            Main.conn.log(text, false, 2);
        }
    }
}