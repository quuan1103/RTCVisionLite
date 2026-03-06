Tool: ORIGIN

SetToolOrigin(): Cài đặt ROI chạy theo ToolOrigin.
	- INPUT:
		+ RTCRectangle ROI1: ROI1
		+ + RTCRectangle ROI1: ROI2
		+ Tuple<Point, double> ToolOrigin: ToolOrigin
	- Chú ý: Mỗi lần ROI bị thay đổi (kích thước, vị trí) hoặc thay đổi Link Origin thì cần gọi lại hàm này.

Run(): Chạy tool FindLine
	-INPUT:
		+ Bitmap InputImage: Ảnh input.
		+ Tuple<Point, double> ToolOrigin: ToolOrigin (cần set lại trước khi Run())
		+ string OriginType: Loại Origin
			. One Line: Tìm Origin bằng 1 cạnh. Gốc đặt tại trung điểm của cạnh. Hướng trục Ox của Origin trùng với hướng của cạnh. 
			. Two Line. Tìm Origin bằng 2 cạnh. Gốc là giao điểm của 2 cạnh. Hướng trục Ox trùng hướng của cạnh thứ nhất. 
		+ string EdgeTransitionROI1: Kiểu tìm cạnh trong ROI1
			. Light to Dark: Tìm cạnh khi chuyển từ sáng sang tối.
			. Dark to Light: Tìm cạnh khi chuyển từ tối sang sáng.
		+ string EdgeTransitionROI2: Kiểu tìm cạnh trong ROI2
			. Light to Dark: Tìm cạnh khi chuyển từ sáng sang tối.
			. Dark to Light: Tìm cạnh khi chuyển từ tối sang sáng.
		+ string EdgeTypeROI1: Loại cạnh trong ROI1
			. FirstEdge: Cạnh đầu tiên.
			. LastEdge: Cạnh cuối cùng.
		+ string EdgeTypeROI2: Loại cạnh trong ROI2
			. FirstEdge: Cạnh đầu tiên.
			. LastEdge: Cạnh cuối cùng.
		+ int EdgeDetectionThresholdROI1: Ngưỡng chênh lệnh giá trị màu xám để phát hiện cạnh trong ROI1.
		+ int EdgeDetectionThresholdROI2: Ngưỡng chênh lệnh giá trị màu xám để phát hiện cạnh trong ROI2.
		+ int OutlierDistanceThresholdROI1: Các điểm nằm ngoài khoảng này sẽ không được tính vào EdgePoints trong ROI1.
		+ int OutlierDistanceThresholdROI2: Các điểm nằm ngoài khoảng này sẽ không được tính vào EdgePoints trong ROI2.
		+ int SamplingPercentROI1: Tỉ lệ lấy mẫu hàng trong ROI1.
		+ int SamplingPercentROI2: Tỉ lệ lấy mẫu hàng trong ROI2.
		+ bool EnableAngleRangeCheck: Bật filter lọc theo hướng Origin. Tool sẽ fail nếu hướng của Origin tìm được nằm ngoài AngleRange.
		+ bool EnableColumnFilter: Bật filter lọc theo cột. Tool sẽ fail nếu gốc của Origin tìm được nằm ngoài ColumnRange.
		+ bool EnableRowFilter: Bật filter lọc theo cột. Tool sẽ fail nếu gốc của Origin tìm được nằm ngoài RowRange.
		+ Tuple<double, double> AngleRange: Giá trị góc nằm trong khoảng từ AngleRange.Item1 đến AngleRange.Item2.
		+ Tuple<double, double> ColumnRange: Giá trị nằm trong khoảng từ ColumnRange.Item1 đến ColumnRange.Item2.
		+ Tuple<double, double> RowRange: Giá trị nằm trong khoảng từ RowRange.Item1 đến RowRange.Item2.
	-OUTPUT:
		+ Tuple<Point, double> OutputOrigin: Origin tìm được.
		+ bool Passed: nếu true : passed; nếu fasle: failed.
		+ string ErrMessage: message lỗi.
		+ Bitmap OutputImage: Ảnh output.
	-Chú ý : Cần gọi hàm SetToolOrigin() trước khi chạy hàm Run().

