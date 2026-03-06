Tool: PIXEL COUNT

SetToolOrigin(): Cài đặt ROI chạy theo ToolOrigin.
	- INPUT:
		+ RTCRectangle ROI: ROI .
		+ Tuple<Point, double> ToolOrigin: ToolOrigin
	- Chú ý: Mỗi lần ROI bị thay đổi (kích thước, vị trí) hoặc thay đổi Link Origin thì cần gọi lại hàm này.

Run(): Chạy tool Pixel Count
	-INPUT:
		+ Bitmap InputImage: Ảnh input.
		+ Tuple<Point, double> ToolOrigin: ToolOrigin (cần set lại trước khi Run())
		+ string PixelColor:
			. White: Đếm pixel trắng.
			. Black: Đếm pixel đen.
		+ string ThresholdMode: Chế độ threshold
			. Auto: Tự động threshold
			. Manual: Threshold với ngưỡng ThresholdRange.
		+ Tuple<int, int> ThresholdRange: Ngưỡng threshold. ThresholdRange.Item1: Ngưỡng thấp và ThresholdRange.Item2: Ngưỡng cao.
		+ Tuple<int, int> PixelCountRange: Khoảng giá trị pixel đếm được.
		+ bool Invert: Nếu true, giá trị pixel đếm được nằm ngoài PixelCountRange thì tool sẽ Passed. Nếu Invert = false, Giá trị pixel đếm được nằm trong PixelCountRange thì tool sẽ Passed
	-OUTPUT:
		+ int Pixels: Số lượng pixel đếm được.
		+ bool Passed: nếu true : passed; nếu fasle: failed.
		+ string ErrMessage: message lỗi.
		+ Bitmap OutputImage: Ảnh output.
	-Chú ý : Cần gọi hàm SetToolOrigin() trước khi chạy hàm Run().

