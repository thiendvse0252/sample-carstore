using System.ComponentModel.DataAnnotations;

namespace car_gallery_app.CustomAttributes {
    public class YearRange : RangeAttribute {
        public YearRange() : base(typeof(int), DateTime.Now.AddYears(-50).Year.ToString(), DateTime.Now.AddYears(1).Year.ToString()) { }
    }
}
