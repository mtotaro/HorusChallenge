using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        public bool IsNotConnected { get; set; }
        protected BaseViewModel()
        {
        }

        ~BaseViewModel()
        {
        }
    }
    public abstract class BaseViewModel<TParameter, TResult> : MvxViewModel<TParameter, TResult>
        where TParameter : class
        where TResult : class
    {
        protected BaseViewModel()
        {
        }

    }

    public abstract class BaseViewModel<TParameter> : MvxViewModel<TParameter>
    where TParameter : class
    {
        protected BaseViewModel()
        {
        }
        /// <summary>
        /// Gets the internationalized string at the given <paramref name="index"/>, which is the key of the resource.
        /// </summary>
    }
}
