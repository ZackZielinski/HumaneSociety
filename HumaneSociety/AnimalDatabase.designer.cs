﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HumaneSociety
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AnimalDatabase")]
	public partial class AnimalDatabaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public AnimalDatabaseDataContext() : 
				base(global::HumaneSociety.Properties.Settings.Default.AnimalDatabaseConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AnimalDatabaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AnimalDatabaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AnimalDatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AnimalDatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<AnimalDatabase> AnimalDatabases
		{
			get
			{
				return this.GetTable<AnimalDatabase>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.AnimalDatabase")]
	public partial class AnimalDatabase
	{
		
		private string _Name;
		
		private System.Nullable<int> _Age;
		
		private string _Type;
		
		private string _Breed;
		
		private string _Color;
		
		private System.Nullable<System.DateTime> _LastVaccineShot;
		
		private System.Nullable<bool> _AdoptionStatus;
		
		private System.Nullable<int> _FoodNeeded;
		
		public AnimalDatabase()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int")]
		public System.Nullable<int> Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this._Age = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="VarChar(50)")]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this._Type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Breed", DbType="VarChar(50)")]
		public string Breed
		{
			get
			{
				return this._Breed;
			}
			set
			{
				if ((this._Breed != value))
				{
					this._Breed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Color", DbType="VarChar(50)")]
		public string Color
		{
			get
			{
				return this._Color;
			}
			set
			{
				if ((this._Color != value))
				{
					this._Color = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastVaccineShot", DbType="DateTime")]
		public System.Nullable<System.DateTime> LastVaccineShot
		{
			get
			{
				return this._LastVaccineShot;
			}
			set
			{
				if ((this._LastVaccineShot != value))
				{
					this._LastVaccineShot = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AdoptionStatus", DbType="Bit")]
		public System.Nullable<bool> AdoptionStatus
		{
			get
			{
				return this._AdoptionStatus;
			}
			set
			{
				if ((this._AdoptionStatus != value))
				{
					this._AdoptionStatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FoodNeeded", DbType="Int")]
		public System.Nullable<int> FoodNeeded
		{
			get
			{
				return this._FoodNeeded;
			}
			set
			{
				if ((this._FoodNeeded != value))
				{
					this._FoodNeeded = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
