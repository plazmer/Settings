﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using finex.EditableConstants.ConstantsEntity;

namespace finex.EditableConstants
{
	partial class ConstantsEntityClientHandlers
	{

		public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
		{
			#region Типы констант
			// Тип константы - строка
			var typeString = finex.EditableConstants.ConstantsEntity.TypeValue.ValString;
			// Тип константы - целое
			var typeInt = finex.EditableConstants.ConstantsEntity.TypeValue.ValInt;
			// Тип константы - вещественное
			var typeDouble = finex.EditableConstants.ConstantsEntity.TypeValue.ValDouble;
			// Тип константы - логическое
			var typeBoolean = finex.EditableConstants.ConstantsEntity.TypeValue.ValBool;
			// Тип константы - текст
			var typeText = finex.EditableConstants.ConstantsEntity.TypeValue.ValText;
			
			// Тип константы - список строк
			var typeListString = finex.EditableConstants.ConstantsEntity.TypeValue.ValListString;
			// Тип константы - список целых
			var typeListInt = finex.EditableConstants.ConstantsEntity.TypeValue.ValListInt;
			// Тип константы - список вещественных
			var typeListDouble = finex.EditableConstants.ConstantsEntity.TypeValue.ValListDouble;
			
			// Тип константы - диапазон целых
			var typeRangeInt = finex.EditableConstants.ConstantsEntity.TypeValue.ValRangeInt;
			// Тип константы - диапазон вещественных
			var typeRangeDouble = finex.EditableConstants.ConstantsEntity.TypeValue.ValRangeDouble;
			
			// Тип константы - строка в Base64
			var typeBase64 = finex.EditableConstants.ConstantsEntity.TypeValue.ValBase64;
			#endregion
			
			var properties = _obj.State.Properties;
			
			#region Значения			
			if (_obj.TypeValue == typeString)
			{
				properties.ValueString.IsVisible = true;
				properties.ValueString.IsRequired = true;
			}
			
			if (_obj.TypeValue == typeInt)
			{
				properties.ValueInt.IsVisible = true;
				properties.ValueInt.IsRequired = true;
			}
			
			if (_obj.TypeValue == typeDouble)
			{
				properties.ValueDouble.IsVisible = true;
				properties.ValueDouble.IsRequired = true;
			}
			
			if (_obj.TypeValue == typeBoolean)
			{
				properties.ValueBool.IsVisible = true;
				properties.ValueBool.IsRequired = true;
			}
			
			if (_obj.TypeValue == typeText)
			{
				properties.ValueText.IsVisible = true;
				properties.ValueText.IsRequired = true;
			}			
			#endregion
			
			#region Диапазоны значений
			if (_obj.TypeValue == typeRangeInt)
			{
				properties.ValueIntFrom.IsVisible = true;
				properties.ValueIntFrom.IsRequired = true;
				
				properties.ValueIntBy.IsVisible = true;
				properties.ValueIntBy.IsRequired = true;
			}
			
			if (_obj.TypeValue == typeRangeDouble)
			{
				properties.ValueDoubleFrom.IsVisible = true;
				properties.ValueDoubleFrom.IsRequired = true;
				
				properties.ValueDoubleBy.IsVisible = true;
				properties.ValueDoubleBy.IsRequired = true;
			}
			#endregion
			
			#region Списки значений	
			var typeList = new List<Sungero.Core.Enumeration> {typeListString, typeListInt, typeListDouble};			
			if (typeList.Contains(_obj.TypeValue.Value))
			{
				properties.ValueCollection.IsVisible = true;
				properties.ValueCollection.IsRequired = true;
				
				var collection = properties.ValueCollection.Properties;
				
				if (_obj.TypeValue == typeListString)
					collection.ValueString.IsVisible = true;
				
				if (_obj.TypeValue == typeListInt)
					collection.ValueInt.IsVisible = true;
				
				if (_obj.TypeValue == typeListDouble)
					collection.ValueDouble.IsVisible = true;
			}
			#endregion
			
			#region Base64 значения
			if (_obj.TypeValue != typeBase64)
				e.HideAction(_obj.Info.Actions.SetValue);
			#endregion
			
			if (!_obj.AllowDelete.HasValue || (_obj.AllowDelete.HasValue && !_obj.AllowDelete.Value) || Sungero.CoreEntities.Users.Current.Login.LoginName != "Integration Service")
				e.HideAction(_obj.Info.Actions.DeleteEntity);
			
			if (Sungero.CoreEntities.Users.Current.Login.LoginName == "Integration Service")
			{
				properties.AllowDelete.IsVisible = true;
				properties.AllowDelete.IsEnabled = true;
			}
		}
	}

}