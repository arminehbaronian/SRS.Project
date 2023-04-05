namespace SRS.Project.Report.Model
{
    public class Invoice
    {
        public Guid id { get; set; }
        public string tracking_code { get; set; }
        public string client_id { get; set; }
        public string device_name { get; set; }
        public string device_model { get; set; }
        public string device_serial_number { get; set; }
        public string problem { get; set; }
        public string problem_client_say { get; set; }
        public string problem_repair_shop_manager_say { get; set; }
        public string repaired_before { get; set; }
        public string repaired_before_result { get; set; }
        public string last_time_healthy { get; set; }
        public string init_repair_cost { get; set; }
        public string repair_cost_des { get; set; }
        public string final_repair_cost { get; set; }
        public string repair_cost_customer_des { get; set; }
        public string status_id { get; set; }
        public string dimensions { get; set; }
        public string weight { get; set; }
        public string priority { get; set; }
        public string deliver_person_name { get; set; }
        public string deliver_person_phone { get; set; }
        public string deliver_des { get; set; }
        public string deliver_date { get; set; }
        public string deliver_time { get; set; }
        public string deleted_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string created_at_fa { get; set; }
        public string updated_at_fa { get; set; }
        public string created_at_fa_date { get; set; }
        public string updated_at_fa_date { get; set; }
        public string created_at_ago { get; set; }
        public string updated_at_ago { get; set; }
        public string createdAtTimeStamp { get; set; }
        public Customer customer { get; set; }
        
    }
    public class Customer
    {
        public Guid id { get; set; }
        public string full_name { get; set; }
        public string avatar { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string mobile { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public string note { get; set; }
        public string deleted_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string phone { get; set; }
        public string customer_type { get; set; }
        public string national_id { get; set; }
        public string province_id { get; set; }
        public string township_id { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string postal_code { get; set; }
        public string site_url { get; set; }
        public string industrial_town_name { get; set; }
        public string first_person_name { get; set; }
        public string first_person_phone { get; set; }
        public string second_person_name { get; set; }
        public string second_person_phone { get; set; }
        public string third_person_name { get; set; }
        public string third_person_phone { get; set; }
        public string fourth_person_name { get; set; }
        public string fourth_person_phone { get; set; }
        public string avatar_url { get; set; }
        public string role_id { get; set; }
        public string role_name { get; set; }
        public string updated_at_fa_date { get; set; }
        public string created_at_fa_date { get; set; }     

    }
}

