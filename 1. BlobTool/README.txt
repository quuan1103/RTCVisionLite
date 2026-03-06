Tool: BLOB

SetToolOrigin(): Cài đặt ROI chạy theo ToolOrigin.
	- INPUT:
		+ RTCRectangle ROI: ROI (ROI có thể bằng null. Khi ROI = null sẽ blob toàn bộ ảnh).
		+ Tuple<Point, double> ToolOrigin: ToolOrigin
	- Chú ý: Mỗi lần ROI bị thay đổi (kích thước, vị trí) hoặc thay đổi Link Origin thì cần gọi lại hàm này.

Run(): Chạy tool Blob
	-INPUT:
		+ Bitmap InputImage: Ảnh input.
		+ Tuple<Point, double> ToolOrigin: ToolOrigin (cần set lại trước khi Run())
		+ string DetectType(Chỉ hoạt động với Threshold Type: Fixed Threshold Range): 
			. Detect Out of Range: Blob giá trị mức nằm ngoài Threshold Ranges.
			. Detect In Range: Blob giá trị xám nằm trong Threshod Ranges.
		+ bool FillHoles: Nếu true sẽ điền đầy tất cả các lỗ.
		+ string GreyLevelThresholdType: 
			. Autothreshold Constrasting Bright Pixels: Blob vùng pixel sáng.
			. Autothreshold Constrasting Dark Pixels: Blob vùng  pixel tối.
			. Fixed Threshold Range: Blob với ngưỡng giá trị xám cố định.
		+ ThresholdRange: Khoảng  giá trị xám được threshold.
		+ bool EnableAreaFilter: Nếu true sẽ lọc theo diện tích.
		+ bool EnableRowFilter: Nếu true sẽ lọc theo hàng của tâm vùng blob.
		+ bool EnableColumnFilter: Nếu true sẽ lọc theo cột của tâm vùng blob.
		+ bool EnableWidthFilter: Nếu true sẽ lọc theo chiều rộng của vùng blob.
		+ bool EnableHeightFilter: Nếu true sẽ lọc theo chiều cao của vùng blob.
		+ bool EnableOuterRadiusFilter: Nếu true sẽ lọc theo bán kính đường tròn ngoại tiếp vùng blob.
		+ bool EnableCircularityFilter: Nếu true sẽ lọc theo độ tròn.
		+ Tuple<double, double> AreaRange: Vùng diện tích sẽ được lọc.
		+ Tuple<double, double> RowRange: Khoảng giá trị của hàng sẽ được lọc.
		+ Tuple<double, double> ColumnRange: Khoảng giá trị của cột sẽ được lọc.
		+ Tuple<double, double> WidthRange: Khoảng giá trị của chiều rộng sẽ được lọc.
		+ Tuple<double, double> HeightRange: Khoảng giá trị của chiều cao sẽ được lọc.
		+ Tuple<double, double> _outerRadiusRange: Khoảng giá trị của bán kính đường tròn ngoại tiếp sẽ được lọc.
		+ Tuple<double, double> _circularityRange: Khoảng giá trị độ tròn sẽ được lọc.
		+ Tuple<int, int> RequireNumberOfBlobs: Khoảng giá trị cho phép của số lượng vùng blob.

	-OUTPUT:
		+ List<VectorOfVectorOfPoint> OutputBlobList: List contour của các vùng blob.
		+ List<double> OutputAreaList: List diện tích của các vùng blob.
		+ List<int> OutputWidthList: List chiều rộng của các vùng blob.
		+ List<int> OutputHeightList: List chiều cao của các vùng blob.
		+ bool Passed: nếu true : passed; nếu fasle: failed.
		+ int NumberOfBlobsFound: Số lượng vùng blob tìm được.
		+ string ErrMessage: message lỗi.
		+ Bitmap OutputImage: Ảnh output.
	-Chú ý : Cần gọi hàm SetToolOrigin() trước khi chạy hàm Run().

ClickMouse(): Lấy thông tin (area, width, height,...) của vùng blob được click chuột.
	-INPUT:
		+ PointF PositionMouse: Tọa độ của chuột theo hệ tọa độ ảnh.

	-OUTPUT:
		+ double AreaActual: Giá trị diện tích của vùng blob được click chuột.
		+ double RowActual: Giá trị hàng của vùng blob được click chuột.
		+ double ColumnActual: Giá trị cột của vùng blob được click chuột.
		+ double OuterRadiusActual: Giá trị bán kính đường tròn ngoại tiếp của vùng blob được click chuột.
		+ double CircularityActual: Giá trị độ tròn của vùng blob được click chuột.
		+ double WidthActual: Giá trị chiều rộng của vùng blob được click chuột.
		+ double HeightActual: Giá trị chiều cao của vùng blob được click chuột.