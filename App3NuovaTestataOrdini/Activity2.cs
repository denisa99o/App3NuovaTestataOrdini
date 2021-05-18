using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App3NuovaTestataOrdini
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {
        public RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;
        private List<Email> mEmails;
        public EditText editText1;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SecondPage);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mEmails = new List<Email>();
            mEmails.Add(new Email() { Name = "Tom", Subject = "wanna hang out?", Message = "I will be around tomorrow" });
            mEmails.Add(new Email() { Name = "Denisa", Subject = "wanna hang out?", Message = "No" });
            mEmails.Add(new Email() { Name = "Alex", Subject = "wanna hang out?", Message = "Yes" });
            //create our layout manager
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mAdapter = new RecyclerAdapter(mEmails);
            mRecyclerView.SetAdapter(mAdapter);

             editText1 = FindViewById<EditText>(Resource.Id.edittext);
            editText1.TextChanged += EditText_TextChanged;
            editText1.AfterTextChanged += EditText_AfterTextChanged;


            

        // Button button2 = FindViewById<Button>(Resource.Id.btn2);
        // button2.Click += delegate { StartActivity(typeof(MainActivity)); };
    }

        
        private void EditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            //throw new NotImplementedException();
            filter(editText1.Text);
        }

        private void EditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
           // throw new NotImplementedException();


        }

        public void filterList(List<Email> filteredList)
        {
          
            mRecyclerView.SetAdapter(null);
            mAdapter = new RecyclerAdapter(filteredList);
            mRecyclerView.SetAdapter(mAdapter);
           
            NotifyDataSetChanged();
        }

        private void NotifyDataSetChanged()
        {
           // throw new NotImplementedException();
        }

        private void filter(String text)
        {
            List<Email> filteredList = new List<Email>();
            foreach (Email item in mEmails)
            {
                if (item.Name.ToLower().Contains(text.ToLower()))
                {
                    filteredList.Add(item);
                }
            }
         filterList(filteredList);
        }



    }

    public class RecyclerAdapter : RecyclerView.Adapter
    {
        private List<Email> mEmails;
        public RecyclerAdapter (List<Email> emails)
        {
            mEmails = emails;
        }
     //   public override int ItemCount => throw new NotImplementedException();

      

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public TextView mName { get; set; }
            public TextView mSubject { get; set; }
            public TextView mMessage { get; set; }

            public MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
          // throw new NotImplementedException();
            View Itemi = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Itemi, parent, false);
            TextView txtName = Itemi.FindViewById<TextView>(Resource.Id.txtName);
            TextView txtSubject = Itemi.FindViewById<TextView>(Resource.Id.txtSubject);
            TextView txtMessage = Itemi.FindViewById<TextView>(Resource.Id.txtMessage);

            MyView view = new MyView(Itemi) { mName = txtName, mSubject = txtSubject, mMessage = txtMessage };
            return view;

        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            // throw new NotImplementedException();
            MyView myHolder = holder as MyView;
            myHolder.mName.Text = mEmails[position].Name;
            myHolder.mSubject.Text = mEmails[position].Subject;
            myHolder.mMessage.Text = mEmails[position].Message;

        }
        public override int ItemCount => mEmails.Count;

       
    }

}