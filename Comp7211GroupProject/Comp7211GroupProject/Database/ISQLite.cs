using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Comp7211GroupProject.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}