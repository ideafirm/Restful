﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restful.Data
{
    /// <summary>
    /// 实体对象类型基类
    /// </summary>
    [Serializable]
    public class EntityObject : IEntityObject, INotifyPropertyChanged
    {
        /// <summary>
        /// 属性改变事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        /// <summary>
        /// 获取或设置已改变的属性集合
        /// </summary>
        public IList<string> ChangedProperties { get; private set; }

        #endregion

        #region EntityObject

        /// <summary>
        /// 基类构造方法
        /// </summary>
        public EntityObject()
        {
            this.ChangedProperties = new List<string>();
        }

        #endregion

        #region OnPropertyChanged

        /// <summary>
        /// 处理实体对象的属性值改变事件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        public void OnPropertyChanged( string propertyName )
        {
            if( this.ChangedProperties.Contains( propertyName ) == false )
            {
                this.ChangedProperties.Add( propertyName );
            }

            if( this.PropertyChanged != null )
            {
                this.PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }

        #endregion

        #region Reset

        /// <summary>
        /// 清空已更新属性集合
        /// </summary>
        public void Reset()
        {
            this.ChangedProperties.Clear();
        }

        #endregion
    }
}
